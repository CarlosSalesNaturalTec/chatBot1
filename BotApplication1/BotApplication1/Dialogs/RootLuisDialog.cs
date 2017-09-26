using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Threading.Tasks;

namespace BotApplication1.Dialogs
{
    [LuisModel("bea072ae-f979-4255-b75d-2ebe073ecf52", "167237839121475dab3d0abc5353c5b3")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        public async Task NoneAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Desculpe, eu não entendi...");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Oi")]
        public async Task OiAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Oi, tudo legal.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Sobre")]
        public async Task SobreAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Eu me chamo RoboZika. Sou um robô de combate ao mosquito Aedes. No momento ainda estou em fase de aprendizado.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Tchau")]
        public async Task TchauAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Vlw, grande abraço, até a próxima.");
            context.Wait(MessageReceived);
        }

    }
}