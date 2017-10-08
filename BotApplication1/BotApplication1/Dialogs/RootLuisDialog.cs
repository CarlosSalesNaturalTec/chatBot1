using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace BotApplication1.Dialogs
{
    [LuisModel("bea072ae-f979-4255-b75d-2ebe073ecf52", "167237839121475dab3d0abc5353c5b3")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        string strBaseURL;

        [LuisIntent("None")]
        public async Task NoneAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Desculpe, não entendi o que disse, pode reformular a pergunta ?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Oi")]
        public async Task OiAsync(IDialogContext context, LuisResult result)
        {
            Activity replyToConversation = ShowButtons(context, "Oi, sou seu Atendente Virtual. Escolha uma opção...!");
            await context.PostAsync(replyToConversation);
            context.Wait(MessageReceivedAsync);
        }

        [LuisIntent("Sobre")]
        public async Task SobreAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Eu sou um robô de combate ao mosquito Aedes. Faço parta da Aedes Patrulha. No momento ainda estou em fase de aprendizado.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Tchau")]
        public async Task TchauAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Vlw, grande abraço, até a próxima.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Dengue")]
        public async Task DengueAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("A Dengue é uma doença viral transmitida por um mosquito. O Aedes Aegypti. Agora cuidado, pessoas infectadas com o vírus pela segunda vez têm um risco significativamente maior de desenvolver doença GRAVE.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Chikungunya")]
        public async Task ChikungunyaAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Rapaz, êta nome difícil...rsrsrs . Mas a Chikungunya assim como a Dengue também é transmitida pelo mosquito Aedes.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Zika")]
        public async Task ZikaAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Pense num problema!!! O Zika Vírus já é considerado uma ameaça à saúde mundial. É TAMBÉM transmitido pelo tal do mosquito Aedes.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Aedes")]
        public async Task AedesAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("O Aedes Aegypti é o mosquito transmissor da Dengue, Zika, Chikungunya e da Febre amarela urbana. Menor do que os mosquitos comuns, é preto com listras brancas no tronco, na cabeça e nas pernas.");
            context.Wait(MessageReceived);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            // Set BaseURL
            context.UserData.TryGetValue<string>(
                "CurrentBaseURL", out strBaseURL);

            // Get the text passed
            var message = await argument;

            switch (message.Text)
            {
                #region GAME
                case "Game":

                    // Create a reply Activity
                    Activity replyToEntrar = (Activity)context.MakeMessage();
                    replyToEntrar.Recipient = replyToEntrar.Recipient;
                    replyToEntrar.Type = "message";

                    string strEntrar =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/Imagem1.png");

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

                #region GAME - CONHECER DESAFIO
                case "Como Funciona":

                    string str1 = "Este é um game cujo objetivo é eliminar de todas as formas o Aedes Aegypti que é o mosquito causador da Dengue, Zika, Chincungunha, Microcefalia e Febre Amarela.";
                    string str2 = "Você pode participar de duas formas:";
                    string str3 = "1) Virtualmente: recrutando Agentes Virtuais em nosso Reality Game.";
                    string str4 = "2) Na Prática: denunciando focos do mosquito em sua cidade.";
                    string str5 = "Sua evolução será convertida em moedas virtuais que você pode usar para subir de nível no game ou trocar por Miniaturas reais dos nossos Mascotes.";

                    // Send the reply
                    await context.PostAsync(str1);
                    await context.PostAsync(str2);
                    await context.PostAsync(str3);
                    await context.PostAsync(str4);
                    await context.PostAsync(str5);

                    string game_str1 = "Comerçar a Jorgar ?";
                    PromptDialog.Confirm(
                       context,
                       GameStart,
                       game_str1,
                       "Desculpa, não entedi.");
                    break;
                #endregion

                #region GAME - PATRULHA
                case "Patrulha":

                    // Create a reply Activity
                    Activity replyToPatrulha = (Activity)context.MakeMessage();
                    replyToPatrulha.Recipient = replyToPatrulha.Recipient;
                    replyToPatrulha.Type = "message";

                    string strPatrulha =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/Imagem1.png");

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

                #region GAME - PATRULHA - NOVO AGENTE
                case "Novo Agente":
                    // Create a reply Activity
                    Activity replyToPatrulhaNovo = (Activity)context.MakeMessage();
                    replyToPatrulhaNovo.Recipient = replyToPatrulhaNovo.Recipient;
                    replyToPatrulhaNovo.Type = "message";

                    string strPatrulhaNovo =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/Imagem1.png");

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

                #region GAME - PATRULHA - NOVO AGENTE - RECRUTA
                case "Agente Recruta":

                    string recruta_str0 = "AGENTE RECRUTA";
                    string recruta_str1 = "Valor: 500 Moedas";
                    string recruta_str2 = "Eficiência: 60 Mosquitos por Hora";
                    string recruta_str3 = "Seu Saldo : 1.000 Moedas";
                    string recruta_str4 = "Comprar Agente";

                    // Send the reply
                    await context.PostAsync(recruta_str0);
                    await context.PostAsync(recruta_str1);
                    await context.PostAsync(recruta_str2);
                    await context.PostAsync(recruta_str3);

                    PromptDialog.Confirm(
                       context,
                       RecrutaComprar,
                       recruta_str4,
                       "Desculpa, não entedi.");
                    break;
                #endregion

                #region GAME - PATRULHA - NOVO AGENTE - COMBATENTE
                case "Agente Combatente":
                    string Combatente_str0 = "AGENTE COMBATENTE";
                    string Combatente_str1 = "Valor: 5.000 Moedas";
                    string Combatente_str2 = "Eficiência: 600 Mosquitos por Hora";
                    string Combatente_str3 = "Seu Saldo : 1.000 Moedas";
                    string Combatente_str4 = "Recrutar Agente";

                    // Send the reply
                    await context.PostAsync(Combatente_str0);
                    await context.PostAsync(Combatente_str1);
                    await context.PostAsync(Combatente_str2);
                    await context.PostAsync(Combatente_str3);

                    PromptDialog.Confirm(
                       context,
                       CombatenteComprar,
                       Combatente_str4,
                       "Desculpa, não entedi.");
                    break;
                #endregion

                #region GAME - PATRULHA - NOVO AGENTE - OFICIAL
                case "Agente Oficial":
                    string Oficial_str0 = "AGENTE OFICIAL";
                    string Oficial_str1 = "Valor: 10.000 Moedas";
                    string Oficial_str2 = "Eficiência: 6.000 Mosquitos por Hora";
                    string Oficial_str3 = "Seu Saldo : 1.000 Moedas";
                    string Oficial_str4 = "Recrutar Agente";

                    // Send the reply
                    await context.PostAsync(Oficial_str0);
                    await context.PostAsync(Oficial_str1);
                    await context.PostAsync(Oficial_str2);
                    await context.PostAsync(Oficial_str3);

                    PromptDialog.Confirm(
                       context,
                       OficialComprar,
                       Oficial_str4,
                       "Desculpa, não entedi.");
                    break;
                #endregion

                #region GAME - PATRULHA - NOVO AGENTE - MEDICO
                case "Agente Médico":
                    string Medico_str0 = "AGENTE MÉDICO";
                    string Medico_str1 = "Valor: 10.000 Moedas";
                    string Medico_str2 = "Eficiência: 10 pacientes atendidos por Dia";
                    string Medico_str3 = "Seu Saldo : 1.000 Moedas";
                    string Medico_str4 = "Recrutar Agente";

                    // Send the reply
                    await context.PostAsync(Medico_str0);
                    await context.PostAsync(Medico_str1);
                    await context.PostAsync(Medico_str2);
                    await context.PostAsync(Medico_str3);

                    PromptDialog.Confirm(
                       context,
                       MedicoComprar,
                       Medico_str4,
                       "Desculpa, não entedi.");
                    break;
                #endregion


                #region GAME - PATRULHA - MEUS AGENTES
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

                #region GAME - PATRULHA - LABORATORIO
                case "Laboratorio":

                    string lab_str1 = "Os Agentes que vc recrutou trabalham aqui. Eles Caçam os mosquitos e os trazem para cá.";
                    string lab_str2 = "Vc precisará estar atento para limpar sempre o laborarório, caso contrário os mosquitos fugirão e voltarãm a ameaçar a sua casa Virtual.";
                    string lab_str3 = "Se vc deixar os mosquitos fugirem (não visitando o laboratório ou não recrutando nenhum agente)";
                    string lab_str4 = "o seu avatar será picado pelo mosquito e ficará doente.";

                    await context.PostAsync(lab_str1);
                    await context.PostAsync(lab_str2);
                    await context.PostAsync(lab_str3);
                    await context.PostAsync(lab_str4);

                    Activity replyToConversationLAB =
                         ShowButtonsGame(context, "O que gostaria de fazer agora ?");

                    await context.PostAsync(replyToConversationLAB);
                    context.Wait(MessageReceivedAsync);

                    break;
                #endregion

                #region GAME - PATRULHA - MEU SALDO
                case "Saldo":

                    string SLD_str1 = "Aqui vc visualiza a quantidade de mosquitos que seus agentes caçaram e poderá trocá-los por moedas virtuais.";
                    string SLD_str2 = "Com elas vc pode recrutar mais Agentes Virtuais ou trocar por Miniaturas dos nossos mascotes.";
                    string SLD_str3 = "01 Miniatura = 100.000 moedas + 100 pacientes atendidos";

                    await context.PostAsync(SLD_str1);
                    await context.PostAsync(SLD_str2);
                    await context.PostAsync(SLD_str3);

                    Activity replyToConversationSld =
                         ShowButtonsGame(context, "O que gostaria de fazer agora ?");

                    await context.PostAsync(replyToConversationSld);
                    context.Wait(MessageReceivedAsync);

                    break;
                #endregion

                #region GAME - MARATONA
                case "Maratona":

                    // Create a reply Activity
                    Activity replyToMaratona = (Activity)context.MakeMessage();
                    replyToMaratona.Recipient = replyToMaratona.Recipient;
                    replyToMaratona.Type = "message";

                    string strMaratona =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/Imagem1.png");

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

                #region GAME - MARATONA - INICIANTE
                case "Maratona Iniciante":

                    string ini_str1 = "Desefie a tropa de Mosquitos e ganhe mais Moedas e Medalhes";
                    string ini_str2 = "Perguntas e Respostas - Nível Iniciante";
                    string ini_str3 = "Agaurde conclusão da Plataforma";

                    await context.PostAsync(ini_str1);
                    await context.PostAsync(ini_str2);
                    await context.PostAsync(ini_str3);

                    Activity replyToConversationIni =
                         ShowButtonsGame(context, "O que gostaria de fazer agora ?");

                    await context.PostAsync(replyToConversationIni);
                    context.Wait(MessageReceivedAsync);

                    break;
                #endregion

                #region GAME - MARATONA - COMBATENTE
                case "Maratona Combatente":

                    string COMB_str1 = "Desefie a tropa de Mosquitos e ganhe mais Moedas e Medalhes";
                    string COMB_str2 = "Perguntas e Respostas - Nível Médio";
                    string COMB_str3 = "Agaurde conclusão da Plataforma";

                    await context.PostAsync(COMB_str1);
                    await context.PostAsync(COMB_str2);
                    await context.PostAsync(COMB_str3);

                    Activity replyToConversationComb =
                         ShowButtonsGame(context, "O que gostaria de fazer agora ?");

                    await context.PostAsync(replyToConversationComb);
                    context.Wait(MessageReceivedAsync);

                    break;
                #endregion

                #region GAME - MARATONA - EXPERT
                case "Maratona Expert":

                    string EXP_str1 = "Desefie a tropa de Mosquitos e ganhe mais Moedas e Medalhes";
                    string EXP_str2 = "Perguntas e Respostas - Nível Avançado";
                    string EXP_str3 = "Agaurde conclusão da Plataforma";

                    await context.PostAsync(EXP_str1);
                    await context.PostAsync(EXP_str2);
                    await context.PostAsync(EXP_str3);

                    Activity replyToConversationExp =
                         ShowButtonsGame(context, "O que gostaria de fazer agora ?");

                    await context.PostAsync(replyToConversationExp);
                    context.Wait(MessageReceivedAsync);

                    break;
                #endregion

                #region GAME - FOCOS REAIS
                case "Focos":
                    string foco_str1 = "Denuncie focos reais do Mosquito na sua cidade e Ganhe muito mais Moedas e Medalhas.";
                    await context.PostAsync(foco_str1);

                    Activity replyToConversationdeNUNC =
                         ShowButtonsGame(context, "O que gostaria de fazer agora ?");

                    await context.PostAsync(replyToConversationdeNUNC);
                    context.Wait(MessageReceivedAsync);

                    break;
                #endregion

                #region GAME - PODIUM
                case "Podium":

                    // Create a reply Activity
                    Activity replyToPodium = (Activity)context.MakeMessage();
                    replyToPodium.Recipient = replyToPodium.Recipient;
                    replyToPodium.Type = "message";

                    string strPodium =
                        String.Format(@"{0}/{1}",
                        strBaseURL,
                        "Images/Imagem1.png");

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
                        "Images/Imagem1.png");

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

                #region APOIO - SOLICITAR VISITA
                case "Visita":

                    string str0 = "Informe sua Localização";

                    // Send the reply
                    await context.PostAsync(str0);
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
                        "Images/Imagem1.png");

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
                        "Images/Imagem1.png");

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
                        "Images/Imagem1.png");

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
                Activity replyToConversation =
                         ShowButtonsAgentes(context, "Escolha um Agente");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);
            }
            else // They said no
            {
                Activity replyToConversation =
                         ShowButtons(context, "Ok. Sem problemas. Estou por aqui às suas ordens.");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);
            }
        }

        private async Task GameStart(IDialogContext context, IAwaitable<bool> result)
        {

            // Get the response from the user
            var confirm = await result;

            if (confirm) // They said yes
            {
                // Create a response
                // This time call the ** ShowButtons ** method
                Activity replyToConversation =
                    ShowButtonsGame(context, "Gostei!!! Vamos lá então, escolha uma opção...");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);

            }
            else // They said no
            {
                Activity replyToConversation =
                         ShowButtons(context, "Ok, sem problemas. Podemos conversar então... Fala ai qualquer coisa...rsrsrs");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);
            }
        }

        private async Task RecrutaComprar(IDialogContext context, IAwaitable<bool> result)
        {

            // Get the response from the user
            var confirm = await result;

            if (confirm) // They said yes
            {
                string NA_str1 = "Agente Recrutado com Sucesso.";
                string NA_str2 = "Seu Saldo: 400 moedas";
                string NA_str3 = "Agente já está Caçando Mosquitos. Daqui a uma hora te lembrarei para vc trocar os mosquitos caçados por Novas Moedas";
                await context.PostAsync(NA_str1);
                await context.PostAsync(NA_str2);
                await context.PostAsync(NA_str3);

                context.Wait(MessageReceivedAsync);

            }
            else // They said no
            {
                Activity replyToConversation =
                         ShowButtonsAgentes(context, "Escolha um Agente!");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);
            }
        }

        private async Task CombatenteComprar(IDialogContext context, IAwaitable<bool> result)
        {

            // Get the response from the user
            var confirm = await result;

            if (confirm) // They said yes
            {
                string NA_str1 = "Humm. Você não tem saldo suficiente para comprar este Agente. Ele custa 5.000 moedas e vc só tem 1.000 moedas em sua conta.";
                string NA_str2 = "Tente comprar outro robô para oqual vc tenha moedas suficientes.";
                await context.PostAsync(NA_str1);
                await context.PostAsync(NA_str2);

                // Create a response
                // This time call the ** ShowButtons ** method
                Activity replyToConversation =
                    ShowButtonsAgentes(context, "Vamos lá, não desista!!!!");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);

            }
            else // They said no
            {
                Activity replyToConversation =
                         ShowButtonsAgentes(context, "Escolha!");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);
            }
        }

        private async Task OficialComprar(IDialogContext context, IAwaitable<bool> result)
        {

            // Get the response from the user
            var confirm = await result;

            if (confirm) // They said yes
            {
                string NA_str1 = "Humm. Você não tem saldo suficiente para comprar este Agente. Ele custa 10.000 moedas e vc só tem 1.000 moedas em sua conta.";
                string NA_str2 = "Tente comprar outro robô para o qual vc tenha moedas suficientes.";
                await context.PostAsync(NA_str1);
                await context.PostAsync(NA_str2);

                // Create a response
                // This time call the ** ShowButtons ** method
                Activity replyToConversation =
                    ShowButtonsAgentes(context, "Vamos lá, não desista!!!!");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);

            }
            else // They said no
            {
                Activity replyToConversation =
                         ShowButtonsAgentes(context, "Escolha outro agente!");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);
            }
        }

        private async Task MedicoComprar(IDialogContext context, IAwaitable<bool> result)
        {

            // Get the response from the user
            var confirm = await result;

            if (confirm) // They said yes
            {
                string NA_str1 = "Humm. Você não tem saldo suficiente para comprar este Agente. Ele custa 10.000 moedas e vc só tem 1.000 moedas em sua conta.";
                string NA_str2 = "Tente comprar outro robô para o qual vc tenha moedas suficientes.";
                await context.PostAsync(NA_str1);
                await context.PostAsync(NA_str2);

                // Create a response
                // This time call the ** ShowButtons ** method
                Activity replyToConversation =
                    ShowButtonsAgentes(context, "Vamos lá, não desista!!!!");

                await context.PostAsync(replyToConversation);
                context.Wait(MessageReceivedAsync);

            }
            else // They said no
            {
                Activity replyToConversation =
                         ShowButtonsAgentes(context, "Escolha outro Agente então!");

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
                Title = "Game",
                Value = "Game"
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

        #region BOTÕES MENU GAME
        private static List<CardAction> CreateButtonsEntrar()
        {
            // Create CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Como Funciona",
                Value = "Como Funciona"
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

        #region BOTÕES MENU GAME - START
        private static List<CardAction> CreateButtonsGameStart()
        {
            // Create CardAction buttons 
            // and return to the calling method 
            List<CardAction> cardButtons = new List<CardAction>();

            // Opção 1
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Patrulha",
                Value = "Patrulha"
            };
            cardButtons.Add(CardButton);

            // Opção 2
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Maratona",
                Value = "Maratona"
            };
            cardButtons.Add(CardButton);


            // Opção 3
            CardButton = new CardAction()
            {
                Type = "imBack",
                Title = "Focos Reais",
                Value = "Focos"
            };
            cardButtons.Add(CardButton);

            // Opção 4
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


        #region BOTÕES MENU GAME - PATRULHA
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

        #region BOTÕES MENU GAME - PATRULHA - NOVO AGENTE
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

        #region BOTÕES MENU GAME - MARATONA
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

        #region BOTÕES MENU GAME - PODIUM
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

        #region Mostrar Botões Menu Inicial
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

        #region Mostrar Botões Game
        private static Activity ShowButtonsGame(IDialogContext context, string strText)
        {
            // Create a reply Activity
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Text = strText;
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "message";

            // Call the CreateButtons utility method 
            // that will create 5 buttons to put on the Here Card
            List<CardAction> cardButtons = CreateButtonsGameStart();

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

        #region Mostrar Botões Novo Agente
        private static Activity ShowButtonsAgentes(IDialogContext context, string strText)
        {
            // Create a reply Activity
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Text = strText;
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "message";

            // Call the CreateButtons utility method 
            // that will create 5 buttons to put on the Here Card
            List<CardAction> cardButtons = CreateButtonsPatrulhaNovo();

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