using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalNoticias.Models
{
    public class RepositorioNoticias
    {
        static List<Noticia> listaNoticias = new List<Noticia>();

        public static List<Noticia> ListaNoticias
        {
            get
            {
                if (listaNoticias.Count == 0) // verificando se a lista é VAZIA
                {
                    CriarNoticias();      // método responsável por cria as noticias FIXAS
                }
                return listaNoticias;
            }
            //set => listaNoticias = value; 
            //o SET será excluído pois não iremos permitir a inclusão de
            //notícias, estas serão FIXAS
        }

        public static void InserirNoticias(Noticia noticia)
        {
            // este código é necessário somente para listas fixas e quando o usuário
            // não acessa a tela INDEX antes da tela CADASTRAR pois é na tela 
            // INDEX que criamos a lista fixa de notícias
            if (listaNoticias.Count == 0) // verificando se a lista é VAZIA
            {
                CriarNoticias();      // método responsável por cria as noticias FIXAS
            }
            ListaNoticias.Add(noticia);
        }

        private static void CriarNoticias()
        {
            listaNoticias = new List<Noticia>();

            listaNoticias.Add
                (
                new Noticia
                {
                    Id = 1,
                    Autor = "Adriano Camacho",
                    Titulo = "OpenSea anuncia atualização para criadores e contrato inteligente",
                    Conteudo = "Nesta semana, a plataforma de leilões de tokens não-fungíveis (NFT) OpenSea anunciou " +
                    "importantes atualizações para os criadores de conteúdo. Segundo a empresa, a novidade deve facilitar" +
                    " a circulação de obras em seu mercado, além de oferecer uma experiência mais rica, personalizada e " +
                    "imersiva aos usuários. A principal mudança em questão trata-se das páginas de lançamento personalizadas, " +
                    "que além dos seus próprios benefícios, também devem garantir maior destaque aos criadores na página" +
                    " inicial da plataforma. Neste novo formato, os usuários poderão incluir informações sobre o lançamento, " +
                    "configurar um cronograma de cunhagem para as NFTs, montar uma contagem regressiva para metas ou exibir as " +
                    "obras em uma galeria — tudo favorecendo sua própria narrativa. Contratos inteligentes seguros e outros " +
                    "recursos Em complemento, há o lançamento de um contrato inteligente desenvolvido pela própria OpenSea." +
                    "O recurso foi batizado de SeaDrop e tem o objetivo de aliviar os criadores da burocracia técnica " +
                    "envolvendo o ajuste de códigos em suas campanhas.A empresa comenta: Desenvolver um contrato inteligente " +
                    "seguro que pode orquestrar lançamentos em vários estágios é um dos elementos mais importantes e " +
                    "tecnicamente complexos, explica. Agora os criadores podem pular essa etapa inteiramente usando o SeaDrop.",
                    Data = DateTime.Today
                }
                );

            listaNoticias.Add
                (
                new Noticia
                {
                    Id = 2,
                    Autor = "Jorge Marin",
                    Titulo = "Internet no Brasil é 7 vezes mais cara que nos EUA",
                    Conteudo = "O preço da internet no Brasil é sete vezes mais alto do que nos EUA, diz uma pesquisa divulgada " +
                    "nesta quinta-feira (22). Elaborada pela empresa de cibersegurança holandesa Surfshark, a Digital Quality " +
                    "of Life 2022 avaliou a qualidade do bem-estar digital em 117 países, o equivalente a 92% da população mundial." +
                    " O estudo levou em conta cinco aspectos – que chamou de “pilares” – que impactam diretamente a qualidade de " +
                    "vida digital geral de uma determinada população: o custo da internet, sua qualidade, infraestrutura eletrônica, " +
                    "segurança e uso pelo governo. Para avaliar o impacto do custo, por exemplo, os pesquisadores avaliaram que um " +
                    "trabalhador brasileiro que ganha um salário mínimo precisa trabalhar por 399 minutos (o equivalente a 6h40) " +
                    "para contratar um plano de internet banda larga mais barato. Isso representa sete vezes mais que os EUA," +
                    " onde bastam 57 minutos para ter acesso a uma conexão rápida e estável.",
                    Data = DateTime.Today.AddDays(-5)
                }
                );

            listaNoticias.Add
                (
                new Noticia
                {
                    Id = 3,
                    Autor = "Fernando Sousa",
                    Titulo = "7 motivos pelos quais você ainda precisa de um pen drive em 2022",
                    Conteudo = "Ter um pen drive em 2022 ainda pode ser útil. Além de funcionar como uma solução de armazenamento de " +
                    "dados, o dispositivo de memória flash tem várias utilidades práticas para o dia a dia — mesmo competindo com outras " +
                    "tecnologias mais avançadas. Com um custo baixo e sendo compatível com uma grande variedade de aparelhos, " +
                    "o pen drive pode ser uma ferramenta estratégica para quem trabalha na área de TI ou mesmo para quem precisa " +
                    "levar consigo alguns arquivos essenciais com facilidade. Se você tem um pen drive sobrando aí, a lista que o " +
                    "TechTudo apresenta abaixo vai te ajudar a encontrar diversas novas usabilidades para sua unidade de armazenamento" +
                    " externo, tornando seu pen drive uma ferramenta poderosa para reparo, backup e até mesmo produtividade. " +
                    "1.Pen drive roda sistemas operacionais no PC 2.Portabilidade e praticidade " +
                    "3.Sistemas de armazenamento em nuvem são limitados 4.Documentos confidenciais " +
                    "5.Você pode instalar jogos no seu pen drive",
                    Data = DateTime.Today.AddMonths(-2)
                }
                );

            listaNoticias.Add
                (
                new Noticia
                {
                    Id = 4,
                    Autor = "Danilo Paulo de Oliveira",
                    Titulo = "Leilão tem Apple Watch, Mi Band, Amazfit e Xbox por preços baixos",
                    Conteudo = "A Receita Federal abriu um leilão com diversos produtos eletrônicos para as cidades de Natal (RN) " +
                    "e Recife (PE). Apple Watch, Mi Band, relógios da Amazfit e Xbox One X são alguns dos produtos com preço baixo, " +
                    "ao menos no lance inicial. São dezenas de lotes e boa parte dos produtos estão disponíveis para pessoas físicas. " +
                    "Interessados têm até 30 de setembro às 21h00 para o envio das propostas de valor de compra. Os produtos são fruto " +
                    "de apreensão realizada pelo órgão. Os preços devem ser observados apenas como referência já que podem subir a " +
                    "depender do interesse do público. De acordo com a Receita Federal, os ganhadores do leilão devem retirar os " +
                    "aparelhos de forma presencial, pois o órgão não se responsabiliza pelo envio. Além disso, os equipamentos não" +
                    " têm garantia do fabricante e a Receita não promete o funcionamento. Os relógios e pulseiras inteligentes da " +
                    "Xiaomi dominam os lotes de eletrônicos, que apresentam mais de um produto cada. Um exemplo é o lote 77, que " +
                    "conta com uma unidade do Amazfit Verge Lite, uma unidade do1x Mi Band 4, um Amazfit GTR, dois Amazfit Bip e " +
                    "cinco unidades do Amazfit Bip Lite, com lance inicial de R$ 800 – valor bastante inferior ao preço cobrado " +
                    "por esses modelos no varejo. Já o lote 96 conta com um Apple Watch 6 por R$ 500 de lance inicial. Para pessoas " +
                    "jurídicas, há um número maior de opções, mas os preços iniciais são maiores.",
                    Data = DateTime.Today.AddYears(-1)
                }
                );

            listaNoticias.Add
                (
                new Noticia
                {
                    Id = 5,
                    Autor = "Caroline Silvestre",
                    Titulo = "Como deixar o seu navegador de Internet o mais seguro possível",
                    Conteudo = "Google Chrome, Safari e Microsoft Edge contam com recursos próprios que ajudam a reforçar a " +
                    "segurança e privacidade dos seus dados. Isso porque, ao navegar na Internet, os usuários estão sujeitos a " +
                    "ameaças como malwares, ataques hacker e sites de phishing. Para manter os internautas seguros, o Chrome, " +
                    "por exemplo, oferece o recurso de proteção reforçada, que detecta e alerta o usuário sobre a presença de " +
                    "malwares. Já no Safari, é possível ativar a prevenção inteligente contra rastreamento, que impede que sites " +
                    "compartilhem seus dados de navegação. A disponibilidade e configuração desses recursos variam conforme cada " +
                    "navegador. A seguir, confira como ativar as principais funções de segurança do Google Chrome, Safari e " +
                    "Microsoft Edge",
                    Data = DateTime.Today.AddDays(-1)
                }
                );

            listaNoticias.Add(new Noticia { Id=6,Autor="eu",Titulo="teste",Conteudo="teste teste",Data=DateTime.Today.AddDays(-10)});
        }
    }
}