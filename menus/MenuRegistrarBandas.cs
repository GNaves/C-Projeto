using OpenAI_API;
using SoundGarden.Modelos;

namespace SoundGarden.Menus;

	internal class MenuRegistrarBandas : Menu
	{
        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!;
            Banda banda = new Banda(nomeDaBanda);

            var client = new OpenAIAPI("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");

            var chat = client.Chat.CreateConversation();
            chat.AppendSystemMessage($"Resuma a {nomeDaBanda}, informe a sua data de criação, sua musica e album mais visto e seu maior publico em shows");
            string respota = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
            banda.Resumo = respota;

            bandasRegistradas.Add(nomeDaBanda, banda);
            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
            Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
            Console.ReadKey();
            Console.Clear();
    }
   
    }


