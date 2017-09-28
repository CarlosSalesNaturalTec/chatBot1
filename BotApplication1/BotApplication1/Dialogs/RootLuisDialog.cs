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

    }
}