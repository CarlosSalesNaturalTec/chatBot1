using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using System.Collections.Generic;

namespace BotApplication1
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// MEU
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {

            #region Set CurrentBaseURL and ChannelAccount
            // Get the base URL that this service is running at
            // This is used to show images
            string CurrentBaseURL =
                    this.Url.Request.RequestUri.AbsoluteUri.Replace(@"api/messages", "");

            // Create an instance of BotData to store data
            BotData objBotData = new BotData();

            // Instantiate a StateClient to save BotData            
            StateClient stateClient = activity.GetStateClient();

            // Use stateClient to get current userData
            BotData userData = await stateClient.BotState.GetUserDataAsync(
                activity.ChannelId, activity.From.Id);

            // Update userData by setting CurrentBaseURL and Recipient
            userData.SetProperty<string>("CurrentBaseURL", CurrentBaseURL);

            // Save changes to userData
            await stateClient.BotState.SetUserDataAsync(
                activity.ChannelId, activity.From.Id, userData);
            #endregion

            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.DialogPrompt());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Construct a base URL for Image
                // To allow it to be found wherever the application is deployed
                string strCurrentURL =
                    this.Url.Request.RequestUri.AbsoluteUri.Replace(@"api/messages", "");

                // Create a reply message
                Activity replyToConversation = message.CreateReply();
                replyToConversation.Recipient = message.From;
                replyToConversation.Type = "message";
                replyToConversation.Attachments = new List<Attachment>();
                // AttachmentLayout options are list or carousel
                replyToConversation.AttachmentLayout = "carousel";

                #region Card One
                // Full URL to the image
                string strNumberGuesserOpeningCard =
                    String.Format(@"{0}/{1}",
                    strCurrentURL,
                    "Images/NumberGuesserOpeningCard.png");

                // Create a CardImage and add our image
                List<CardImage> cardImages1 = new List<CardImage>();
                cardImages1.Add(new CardImage(url: strNumberGuesserOpeningCard));

                // Create a CardAction to make the HeroCard clickable
                // Note this does not work in some Skype clients
                CardAction btnAiHelpWebsite = new CardAction()
                {
                    Type = "openUrl",
                    Title = "Aedes.online",
                    Value = "https://aedes.online/"
                };

                // Finally create the Hero Card
                // adding the image and the CardAction
                HeroCard plCard1 = new HeroCard()
                {
                    Title = "Aedes Patrulha!",
                    Subtitle = "Inteligência Artificial no combate ao Aedes Aegypti",
                    Images = cardImages1,
                    Tap = btnAiHelpWebsite
                };

                // Create an Attachment by calling the
                // ToAttachment() method of the Hero Card
                Attachment plAttachment1 = plCard1.ToAttachment();

                // Add the Attachment to the reply message
                replyToConversation.Attachments.Add(plAttachment1);
                #endregion

                #region Card Two
                string strAiLogo_smallSquare =
                    String.Format(@"{0}/{1}",
                    strCurrentURL,
                    "Images/mosquitozero.png");

                List<CardImage> cardImages2 = new List<CardImage>();
                cardImages2.Add(new CardImage(url: strAiLogo_smallSquare));

                // CardAction to make the HeroCard clickable
                CardAction btnTutorial = new CardAction()
                {
                    Type = "openUrl",
                    Title = "https://aedes.online/",
                    Value = "https://aedes.online/"
                };

                HeroCard plCard2 = new HeroCard()
                {
                    Title = "Parceria: Mosquito Zero",
                    Subtitle = "https://aedes.online/",
                    Images = cardImages2,
                    Tap = btnTutorial
                };

                Attachment plAttachment2 = plCard2.ToAttachment();
                replyToConversation.Attachments.Add(plAttachment2);
                #endregion

                // Create a ConnectorClient and use it to send the reply message
                var connector =
                    new ConnectorClient(new Uri(message.ServiceUrl));
                var reply =
                    connector.Conversations.SendToConversationAsync(replyToConversation);
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }
           
            return null;
        }
    }
}