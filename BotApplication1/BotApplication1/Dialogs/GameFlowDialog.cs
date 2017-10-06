using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotApplication1.Dialogs
{
    [Serializable]
    public class GameFlowDialog : IDialog<object>
    {

        public async Task StartAsync(IDialogContext context)
        {         
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {

            // Get the text passed
            //var message = await argument;

            string CongratulationsStringPrompt = "Aleluia. Continuar ?";

            // Prompt SIM/NAO
            PromptDialog.Confirm( context, PlayAgainAsync, CongratulationsStringPrompt, "Opa!");
        }

        private async Task PlayAgainAsync(IDialogContext context, IAwaitable<bool> result)
        {

            // Get the response from the user
            var confirm = await result;

            if (confirm) // They said yes
            {
                // Start a new Game
                await context.PostAsync("voce respondeu sim");
                context.Wait(MessageReceivedAsync);
            }
            else // They said no
            {
                await context.PostAsync("voce respondeu sim");
                context.Wait(MessageReceivedAsync);
            }
        }
    }
}