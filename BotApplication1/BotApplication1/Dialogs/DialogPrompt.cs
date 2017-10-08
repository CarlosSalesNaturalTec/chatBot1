using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Text;
using System.Collections.Generic;

namespace BotApplication1.Dialogs
{
    [Serializable]
    public class DialogPrompt : IDialog<object>
    {
        string strBaseURL;
        string str0, str1, str2, str3, str4, str5;

        #region public async Task StartAsync(IDialogContext context)
        public async Task StartAsync(IDialogContext context)
        {
            // Start the Dialog
            context.Wait(MessageReceivedAsync);
        }
        #endregion

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            // Set BaseURL
            context.UserData.TryGetValue<string>(
                "CurrentBaseURL", out strBaseURL);

            // Get the text passed
            var message = await argument;

            switch (message.Text)
            {
                #region ENTRAR
                case "Entrar":

                    // Create a reply Activity
                    Activity replyToEntrar = (Activity)context.MakeMessage();
                    replyToEntrar.Recipient = replyToEntrar.Recipient;
                    replyToEntrar.Type = "message";

                    string strEntrar =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/NumberGuesserCard.png");

                    List<CardImage> cardImagesEntrar = new List<CardImage>();
                    cardImagesEntrar.Add(new CardImage(url: strEntrar));

                    // Create the Buttons
                    // Call the CreateButtons utility method
                    List<CardAction> cardButtonsEntrar = CreateButtonsEntrar();

                    // Create the Hero Card
                    // Set the image and the buttons
                    HeroCard plCardEntrar = new HeroCard()
                    {
                        Images = cardImagesEntrar,
                        Buttons = cardButtonsEntrar,
                    };

                    // Create an Attachment by calling the
                    // ToAttachment() method of the Hero Card                
                    Attachment plAttachmentEntrar = plCardEntrar.ToAttachment();
                    // Attach the Attachment to the reply
                    replyToEntrar.Attachments.Add(plAttachmentEntrar);
                    // set the AttachmentLayout as 'list'
                    replyToEntrar.AttachmentLayout = "list";

                    // Send the reply
                    await context.PostAsync(replyToEntrar);
                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region ENTRAR - CONHECER DESAFIO
                case "Desafio":

                    string str0 = "Oi ;)";
                    string str1 = "Este é um game cujo objetivo é eliminar de todas as formas o Aedes Aegypti que é o mosquito causador da Dengue, Zika, Chincungunha, Microcefalia e Febre Amarela.";
                    string str2 = "Você pode participar de duas formas:";
                    string str3 = "1) Virtualmente: recrutando Agentes Virtuais em nosso Reality Game.";
                    string str4 = "2) Na Prática: denunciando focos do mosquito em sua cidade.";
                    string str5 = "Sua evolução será convertida em moedas virtuais que você pode usar para subir de nível no game ou trocar por Miniaturas reais dos nossos Mascotes.";

                    // Send the reply
                    await context.PostAsync(str0);
                    await context.PostAsync(str1);
                    await context.PostAsync(str2);
                    await context.PostAsync(str3);
                    await context.PostAsync(str4);
                    await context.PostAsync(str5);

                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region ENTRAR - PATRULHA
                case "Patrulha":

                    // Create a reply Activity
                    Activity replyToPatrulha = (Activity)context.MakeMessage();
                    replyToPatrulha.Recipient = replyToPatrulha.Recipient;
                    replyToPatrulha.Type = "message";

                    string strPatrulha =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/NumberGuesserCard.png");

                    List<CardImage> cardImagesPatrulha = new List<CardImage>();
                    cardImagesPatrulha.Add(new CardImage(url: strPatrulha));

                    // Create the Buttons
                    // Call the CreateButtons utility method
                    List<CardAction> cardButtonsPatrulha = CreateButtonsPatrulha();

                    // Create the Hero Card
                    // Set the image and the buttons
                    HeroCard plCardPatrulha = new HeroCard()
                    {
                        Images = cardImagesPatrulha,
                        Buttons = cardButtonsPatrulha,
                    };

                    // Create an Attachment by calling the
                    // ToAttachment() method of the Hero Card                
                    Attachment plAttachmentPatrulha = plCardPatrulha.ToAttachment();
                    // Attach the Attachment to the reply
                    replyToPatrulha.Attachments.Add(plAttachmentPatrulha);
                    // set the AttachmentLayout as 'list'
                    replyToPatrulha.AttachmentLayout = "list";

                    // Send the reply
                    await context.PostAsync(replyToPatrulha);
                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region ENTRAR - PATRULHA - NOVO AGENTE
                case "Novo Agente":
                    // Create a reply Activity
                    Activity replyToPatrulhaNovo = (Activity)context.MakeMessage();
                    replyToPatrulhaNovo.Recipient = replyToPatrulhaNovo.Recipient;
                    replyToPatrulhaNovo.Type = "message";

                    string strPatrulhaNovo =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/NumberGuesserCard.png");

                    List<CardImage> cardImagesPatrulhaNovo = new List<CardImage>();
                    cardImagesPatrulhaNovo.Add(new CardImage(url: strPatrulhaNovo));

                    // Create the Buttons
                    // Call the CreateButtons utility method
                    List<CardAction> cardButtonsPatrulhaNovo = CreateButtonsPatrulhaNovo();

                    // Create the Hero Card
                    // Set the image and the buttons
                    HeroCard plCardPatrulhaNovo = new HeroCard()
                    {
                        Images = cardImagesPatrulhaNovo,
                        Buttons = cardButtonsPatrulhaNovo,
                    };

                    // Create an Attachment by calling the
                    // ToAttachment() method of the Hero Card                
                    Attachment plAttachmentPatrulhaNovo = plCardPatrulhaNovo.ToAttachment();
                    // Attach the Attachment to the reply
                    replyToPatrulhaNovo.Attachments.Add(plAttachmentPatrulhaNovo);
                    // set the AttachmentLayout as 'list'
                    replyToPatrulhaNovo.AttachmentLayout = "list";

                    // Send the reply
                    await context.PostAsync(replyToPatrulhaNovo);

                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region ENTRAR - PATRULHA - MEUS AGENTES
                case "Meus Agentes":

                    string MA_str1 = "Você ainda não Recrutou Nenhum Agente.";
                    string MA_str2 = "Recrutar Agente Agora ?";

                    await context.PostAsync(MA_str1);

                    PromptDialog.Confirm(
                       context,
                       NovoAgente,
                       MA_str2,
                       "Desculpa, não entedi.");

                    break;
                #endregion

                #region ENTRAR - PATRULHA - LABORATORIO
                case "Laboratorio":

                    string lab_str1 = "Os Agentes que vc recrutou trabalham aqui. Eles Caçam os mosquitos e os trazem para cá.";
                    string lab_str2 = "Vc precisará estar atento para limpar sempre o laborarório, caso contrário os mosquitos fugirão e voltarãm a ameaçar a sua casa Virtual.";
                    string lab_str3 = "Se vc deixar os mosquitos fugirem (não visitando o laboratório ou não recrutando nenhum agente)";
                    string lab_str4 = "o seu avatar será picado pelo mosquito e ficará doente.";

                    await context.PostAsync(lab_str1);
                    await context.PostAsync(lab_str2);
                    await context.PostAsync(lab_str3);
                    await context.PostAsync(lab_str4);

                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region ENTRAR - PATRULHA - MEU SALDO
                case "Saldo":

                    string SLD_str1 = "Aqui vc visualiza a quantidade de mosquitos que seus agentes caçaram e poderá trocá-los por moedas virtuais.";
                    string SLD_str2 = "Com elas vc pode recrutar mais Agentes Virtuais ou trocar por Miniaturas dos nossos mascotes.";
                    string SLD_str3 = "01 Miniatura = 100.000 moedas + 100 pacientes atendidos";

                    await context.PostAsync(SLD_str1);
                    await context.PostAsync(SLD_str2);
                    await context.PostAsync(SLD_str3);

                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region ENTRAR - MARATONA
                case "Maratona":

                    // Create a reply Activity
                    Activity replyToMaratona = (Activity)context.MakeMessage();
                    replyToMaratona.Recipient = replyToMaratona.Recipient;
                    replyToMaratona.Type = "message";

                    string strMaratona =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/NumberGuesserCard.png");

                    List<CardImage> cardImagesMaratona = new List<CardImage>();
                    cardImagesMaratona.Add(new CardImage(url: strMaratona));

                    // Create the Buttons
                    // Call the CreateButtons utility method
                    List<CardAction> cardButtonsMaratona = CreateButtonsMaratona();

                    // Create the Hero Card
                    // Set the image and the buttons
                    HeroCard plCardMaratona = new HeroCard()
                    {
                        Images = cardImagesMaratona,
                        Buttons = cardButtonsMaratona,
                    };

                    // Create an Attachment by calling the
                    // ToAttachment() method of the Hero Card                
                    Attachment plAttachmentMaratona = plCardMaratona.ToAttachment();
                    // Attach the Attachment to the reply
                    replyToMaratona.Attachments.Add(plAttachmentMaratona);
                    // set the AttachmentLayout as 'list'
                    replyToMaratona.AttachmentLayout = "list";

                    // Send the reply
                    await context.PostAsync(replyToMaratona);
                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region ENTRAR - FOCOS REAIS
                case "Focos":
                    string foco_str1 = "Denuncie focos reais do Mosquito na sua cidade e Ganhe muito mais Moedas e Medalhas.";
                    await context.PostAsync(foco_str1);
                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region ENTRAR - PODIUM
                case "Podium":

                    // Create a reply Activity
                    Activity replyToPodium = (Activity)context.MakeMessage();
                    replyToPodium.Recipient = replyToPodium.Recipient;
                    replyToPodium.Type = "message";

                    string strPodium =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/NumberGuesserCard.png");

                    List<CardImage> cardImagesPodium = new List<CardImage>();
                    cardImagesPodium.Add(new CardImage(url: strPodium));

                    // Create the Buttons
                    // Call the CreateButtons utility method
                    List<CardAction> cardButtonsPodium = CreateButtonsPodium();

                    // Create the Hero Card
                    // Set the image and the buttons
                    HeroCard plCardPodium = new HeroCard()
                    {
                        Images = cardImagesPodium,
                        Buttons = cardButtonsPodium,
                    };

                    // Create an Attachment by calling the
                    // ToAttachment() method of the Hero Card                
                    Attachment plAttachmentPodium = plCardPodium.ToAttachment();
                    // Attach the Attachment to the reply
                    replyToPodium.Attachments.Add(plAttachmentPodium);
                    // set the AttachmentLayout as 'list'
                    replyToPodium.AttachmentLayout = "list";

                    // Send the reply
                    await context.PostAsync(replyToPodium);
                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region APOIO
                case "Apoio":
                    // Create a reply Activity
                    Activity replyToApoio = (Activity)context.MakeMessage();
                    replyToApoio.Recipient = replyToApoio.Recipient;
                    replyToApoio.Type = "message";

                    string strApoio =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/NumberGuesserCard.png");

                    List<CardImage> cardImagesApoio = new List<CardImage>();
                    cardImagesApoio.Add(new CardImage(url: strApoio));

                    // Create the Buttons
                    // Call the CreateButtons utility method
                    List<CardAction> cardButtonsApoio = CreateButtonsApoio();

                    // Create the Hero Card
                    // Set the image and the buttons
                    HeroCard plCardApoio = new HeroCard()
                    {
                        Images = cardImagesApoio,
                        Buttons = cardButtonsApoio,
                    };

                    // Create an Attachment by calling the
                    // ToAttachment() method of the Hero Card                
                    Attachment plAttachmentApoio = plCardApoio.ToAttachment();
                    // Attach the Attachment to the reply
                    replyToApoio.Attachments.Add(plAttachmentApoio);
                    // set the AttachmentLayout as 'list'
                    replyToApoio.AttachmentLayout = "list";

                    // Send the reply
                    await context.PostAsync(replyToApoio);
                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region APOIO - ORIENTAÇÕES
                case "Orientações":
                    // Create a reply Activity
                    Activity replyToOrienta = (Activity)context.MakeMessage();
                    replyToOrienta.Recipient = replyToOrienta.Recipient;
                    replyToOrienta.Type = "message";

                    string strOrienta =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/NumberGuesserCard.png");

                    List<CardImage> cardImagesOrienta = new List<CardImage>();
                    cardImagesOrienta.Add(new CardImage(url: strOrienta));

                    // Create the Buttons
                    // Call the CreateButtons utility method
                    List<CardAction> cardButtonsOrienta = CreateButtonsOrienta();

                    // Create the Hero Card
                    // Set the image and the buttons
                    HeroCard plCardOrienta = new HeroCard()
                    {
                        Images = cardImagesOrienta,
                        Buttons = cardButtonsOrienta,
                    };

                    // Create an Attachment by calling the
                    // ToAttachment() method of the Hero Card                
                    Attachment plAttachmentOrienta = plCardOrienta.ToAttachment();
                    // Attach the Attachment to the reply
                    replyToOrienta.Attachments.Add(plAttachmentOrienta);
                    // set the AttachmentLayout as 'list'
                    replyToOrienta.AttachmentLayout = "list";

                    // Send the reply
                    await context.PostAsync(replyToOrienta);
                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region CONHECER
                case "Conhecer":
                    // Create a reply Activity
                    Activity replyToConhecer = (Activity)context.MakeMessage();
                    replyToConhecer.Recipient = replyToConhecer.Recipient;
                    replyToConhecer.Type = "message";

                    string strConhecer =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/NumberGuesserCard.png");

                    List<CardImage> cardImagesConhecer = new List<CardImage>();
                    cardImagesConhecer.Add(new CardImage(url: strConhecer));

                    // Create the Buttons
                    // Call the CreateButtons utility method
                    List<CardAction> cardButtonsConhecer = CreateButtonsConhecer();

                    // Create the Hero Card
                    // Set the image and the buttons
                    HeroCard plCardConhecer = new HeroCard()
                    {
                        Images = cardImagesConhecer,
                        Buttons = cardButtonsConhecer,
                    };

                    // Create an Attachment by calling the
                    // ToAttachment() method of the Hero Card                
                    Attachment plAttachmentConhecer = plCardConhecer.ToAttachment();
                    // Attach the Attachment to the reply
                    replyToConhecer.Attachments.Add(plAttachmentConhecer);
                    // set the AttachmentLayout as 'list'
                    replyToConhecer.AttachmentLayout = "list";

                    // Send the reply
                    await context.PostAsync(replyToConhecer);
                    context.Wait(MessageReceivedAsync);
                    break;
                #endregion

                #region MENU INICIAL
                default:

                    // MENU INICIAL

                    // Create a reply Activity
                    Activity replyToConversation = (Activity)context.MakeMessage();
                    replyToConversation.Recipient = replyToConversation.Recipient;
                    replyToConversation.Type = "message";

                    string strNumberGuesserCard =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/NumberGuesserCard.png");

                    List<CardImage> cardImages = new List<CardImage>();
                    cardImages.Add(new CardImage(url: strNumberGuesserCard));

                    // Create the Buttons
                    // Call the CreateButtons utility method
                    List<CardAction> cardButtons = CreateButtons();

                    // Create the Hero Card
                    // Set the image and the buttons
                    HeroCard plCard = new HeroCard()
                    {
                        Images = cardImages,
                        Buttons = cardButtons,
                    };

                    // Create an Attachment by calling the
                    // ToAttachment() method of the Hero Card                
                    Attachment plAttachment = plCard.ToAttachment();
                    // Attach the Attachment to the reply
                    replyToConversation.Attachments.Add(plAttachment);
                    // set the AttachmentLayout as 'list'
                    replyToConversation.AttachmentLayout = "list";

                    // Send the reply
                    await context.PostAsync(replyToConversation);
                    context.Wait(MessageReceivedAsync);
                    break;
                    #endregion
            }

        }

        private async Task NovoAgente(IDialogContext context, IAwaitable<bool> result)
        {

            // Get the response from the user
            var confirm = await result;

            if (confirm) // They said yes
            {
                string NA_str1 = "Aguarde conclusão da Plataforma";
                await context.PostAsync(NA_str1);
                context.Wait(MessageReceivedAsync);
            }
            else // They said no
            {
                Activity replyToConversation =
                         ShowButtons(context, "Ok. Sem problemas");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);
            }
        }



        // Utility

        #region BOTÕES MENU INICIAL
        private static List<CardAction> CreateButtons()
        {
            // Create 5 CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Entrar",
                Value = "Entrar"
            };
            cardButtons.Add(CardButton);

            // Opção 2
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Preciso de Apoio",
                Value = "Apoio"
            };
            cardButtons.Add(CardButton);

            // Opção 3
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Conheça-nos",
                Value = "Conhecer"
            };
            cardButtons.Add(CardButton);

            return cardButtons;
        }
        #endregion

        #region BOTÕES MENU ENTRAR
        private static List<CardAction> CreateButtonsEntrar()
        {
            // Create CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Conhecer o Desafio",
                Value = "Desafio"
            };
            cardButtons.Add(CardButton);

            // Opção 2
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Patrulha",
                Value = "Patrulha"
            };
            cardButtons.Add(CardButton);

            // Opção 3
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Maratona",
                Value = "Maratona"
            };
            cardButtons.Add(CardButton);


            // Opção 4
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Focos Reais",
                Value = "Focos"
            };
            cardButtons.Add(CardButton);

            // Opção 5
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Podium",
                Value = "Podium"
            };
            cardButtons.Add(CardButton);


            return cardButtons;
        }
        #endregion

        #region BOTÕES MENU ENTRAR - PATRULHA
        private static List<CardAction> CreateButtonsPatrulha()
        {
            // Create CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Novo Agente",
                Value = "Novo Agente"
            };
            cardButtons.Add(CardButton);

            // Opção 2
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Meus Agentes",
                Value = "Meus Agentes"
            };
            cardButtons.Add(CardButton);

            // Opção 3
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Laboratório",
                Value = "Laboratorio"
            };
            cardButtons.Add(CardButton);


            // Opção 4
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Meu Saldo",
                Value = "Saldo"
            };
            cardButtons.Add(CardButton);

            return cardButtons;
        }
        #endregion

        #region BOTÕES MENU ENTRAR - PATRULHA - NOVO AGENTE
        private static List<CardAction> CreateButtonsPatrulhaNovo()
        {
            // Create CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Recruta",
                Value = "Agente Recruta"
            };
            cardButtons.Add(CardButton);

            // Opção 2
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Combatente",
                Value = "Agente Combatente"
            };
            cardButtons.Add(CardButton);

            // Opção 3
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Oficial",
                Value = "Agente Oficial"
            };
            cardButtons.Add(CardButton);


            // Opção 4
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Médico",
                Value = "Agente Médico"
            };
            cardButtons.Add(CardButton);

            return cardButtons;
        }
        #endregion

        #region BOTÕES MENU ENTRAR - MARATONA
        private static List<CardAction> CreateButtonsMaratona()
        {
            // Create CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Iniciante",
                Value = "Maratona Iniciante"
            };
            cardButtons.Add(CardButton);

            // Opção 2
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Combatente",
                Value = "Maratona Combatente"
            };
            cardButtons.Add(CardButton);

            // Opção 3
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Expert",
                Value = "Maratona Expert"
            };
            cardButtons.Add(CardButton);

            return cardButtons;
        }
        #endregion

        #region BOTÕES MENU ENTRAR - PODIUM
        private static List<CardAction> CreateButtonsPodium()
        {
            // Create CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Rancking",
                Value = "Rancking"
            };
            cardButtons.Add(CardButton);

            // Opção 2
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Trocar Moedas",
                Value = "Trocar Moedas"
            };
            cardButtons.Add(CardButton);

            // Opção 3
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Meu Avatar",
                Value = "Meu Avatar"
            };
            cardButtons.Add(CardButton);

            return cardButtons;
        }
        #endregion

        #region BOTÕES MENU APOIO
        private static List<CardAction> CreateButtonsApoio()
        {
            // Create CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Solicitar Visita",
                Value = "Visita"
            };
            cardButtons.Add(CardButton);

            // Opção 2
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Orientações Médicas",
                Value = "Orientações"
            };
            cardButtons.Add(CardButton);

            // Opção 3
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Denunciar Foco",
                Value = "Denunciar"
            };
            cardButtons.Add(CardButton);

            return cardButtons;
        }
        #endregion

        #region BOTÕES MENU APOIO - ORIENTAÇÕES
        private static List<CardAction> CreateButtonsOrienta()
        {
            // Create CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Sintomas",
                Value = "Sintomas"
            };
            cardButtons.Add(CardButton);

            // Opção 2
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Fui Picado",
                Value = "Fui Picado"
            };
            cardButtons.Add(CardButton);

            // Opção 3
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Microcefalia",
                Value = "Microcefalia"
            };
            cardButtons.Add(CardButton);

            return cardButtons;
        }
        #endregion


        #region BOTÕES MENU CONHECER
        private static List<CardAction> CreateButtonsConhecer()
        {
            // Create CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Conheça o Inimigo",
                Value = "Inimigo"
            };
            cardButtons.Add(CardButton);

            // Opção 2
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Conheça a Patrulha",
                Value = "Patrula"
            };
            cardButtons.Add(CardButton);

            return cardButtons;
        }
        #endregion

        #region private static Activity ShowButtons(IDialogContext context, string strText)
        private static Activity ShowButtons(IDialogContext context, string strText)
        {
            // Create a reply Activity
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Text = strText;
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "message";

            // Call the CreateButtons utility method 
            // that will create 5 buttons to put on the Here Card
            List<CardAction> cardButtons = CreateButtons();

            // Create a Hero Card and add the buttons 
            HeroCard plCard = new HeroCard()
            {
                Buttons = cardButtons
            };

            // Create an Attachment
            // set the AttachmentLayout as 'list'
            Attachment plAttachment = plCard.ToAttachment();
            replyToConversation.Attachments.Add(plAttachment);
            replyToConversation.AttachmentLayout = "list";

            // Return the reply to the calling method
            return replyToConversation;
        }
        #endregion
    }
}