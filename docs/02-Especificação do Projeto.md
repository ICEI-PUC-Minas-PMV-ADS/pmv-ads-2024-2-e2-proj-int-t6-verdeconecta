# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

1. Julia, 30 anos, Designer Gráfica: 

   Julia é uma jovem profissional que se preocupa com o impacto ambiental de suas escolhas. Ela decidiu se tornar vegetariana há dois anos por motivos éticos e ambientais. Ela adora cozinhar e experimenta novas receitas vegetarianas nos finais de semana. Para ela, a dieta é uma extensão de seu compromisso com a sustentabilidade. 

2. Andressa, 34 anos, Professora de Yoga: 

   Andressa adotou o vegetarianismo na adolescência como uma forma de alinhar sua alimentação com sua filosofia de vida holística e espiritual. Para ela, ser vegetariana está profundamente conectado com seu estilo de vida e prática de yoga. Ela ensina aos seus alunos sobre os benefícios de uma dieta à base de plantas para o corpo e a mente. 

3. Lucas, 40 anos, Chef de Cozinha Vegetariana: 

   Lucas é um chef especializado em pratos vegetarianos e veganos. Ele dirige um restaurante premiado que se destaca por suas criações inovadoras e saborosas. Ele também oferece workshops e cursos de culinária para ensinar outros chefs e entusiastas a cozinhar pratos sem carne. A paixão de Lucas pela comida e pela filosofia vegetariana é evidente em cada prato que prepara. 

4. Ana, 32 anos, Nutricionista e Consultora de Alimentação Vegetariana: 

   Ana é uma nutricionista especializada em dietas vegetarianas. Ela trabalha com clientes para ajudá-los a adotar e manter uma alimentação equilibrada e saudável. Além de consultas individuais, Ana oferece palestras e escreve artigos sobre os benefícios da alimentação à base de plantas e como planejar uma dieta nutricionalmente completa. 

5. João, 27 anos, Blogger e Influenciador de Alimentação Vegetariana: 

   João é um influenciador digital que se dedica a criar conteúdo sobre receitas, dicas e estilo de vida vegetariano. Suas redes sociais são repletos de receitas criativas, análises de produtos e informações sobre o impacto do vegetarianismo na saúde e no meio ambiente. Ele também colabora com marcas de produtos vegetais para promover uma alimentação mais sustentável. 

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Cliente   | Registrar diariamente refeições        | Controlar nutrientes               |
|Cliente       | Acompanhar nutrientes                  | Controlar nutrientes  |
|Cliente       | Monitorar progresso com gráficos e relatórios               | Acompanhar o progresso   |
|Cliente       | Definir metas                  | Controlar ingestão de alimentos   |
|Cliente       | Ter contato com o nutricionista que está me acompanhando                  |Ajustes rápidos no plano alimentar, respostas a dúvidas imediatas etc   |
|Nutricionista        | Desejo postar dicas nutricionais                  | Ajudar os clientes em seus objetivos   |
|Nutricionista        | Visualizar relatórios detalhados do consumo de nutrientes dos meus pacientes                   |Poder fazer recomendações mais precisas e eficazes    |
|Nutricionista        | Ter contato com o cliente que estou acompanhando                  | Identificação precoce de desvios, adaptação contínua do plano alimentar,     |
|Administrador         | Controle com todos os perfis de usuários                  | Gerenciar contas e solucionar problemas    |
|Administrador         | Gerenciamento de conteúdo                   | Para que o conteúdo do site esteja sempre atualizado e relevante     |
|Administrador         | Monitoramento de Atividade                  | Para entender o comportamento dos usuários     |



## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| A aplicação deve permitir que o usuário avalie uma agência de intercâmbio com base na sua experiência| ALTA | 
|RF-002| A aplicação deve permitir que o usuário inclua comentários ao fazer uma avaliação de uma agência de intercâmbio    | ALTA |
|RF-003| A aplicação deve permitir que o usuário consulte todas as agências de intercâmbio cadastradas ordenando-as com base em suas notas | ALTA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A aplicação deve ser responsiva | MÉDIA | 
|RNF-002| A aplicação deve processar requisições do usuário em no máximo 3s |  BAIXA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
