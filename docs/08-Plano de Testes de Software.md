 # Plano de Testes de Software

Apresente os cenários de testes a serem utilizados na realização dos testes da aplicação. Escolha cenários de testes que demonstrem os requisitos sendo atendidos. 

Os testes funcionais a serem realizados na aplicação são descritos a seguir. [Utilize a estrutura abaixo para cada caso de teste]



|Caso de Teste    | CT-01 – Verificar a funcionalidade do gerenciamento do  cadastro de usuários. |
|:---|:---|
| Requisitos Associados | RF-01 – O sistema deve permitir que seus usuários gerenciem seus cadastros.   |
| Objetivo do Teste | Verificar se o usuário consegue incluir novos cadastros. |
| Passos | 1. Acessar a página de cadastro; 2. Preencher todos os campos obrigatórios do formulário; 3. Clicar no botão "Cadastrar"; 4. Verificar se uma mensagem de sucesso é exibida e se o usuário é redirecionado para a página de login.  |
| Critérios de êxito | O cadastro deve ser realizado com sucesso, exibindo uma mensagem de confirmação e redirecionando o usuário para a página de login  |
| Responsável pela elaborar do caso de Teste | Daianne Paula |

|Caso de Teste    | CT-02– Login de usuários |
|:---|:---|
| Requisitos Associados | RF-02 O sistema deve verificar se o e-mail e senha estão cadastrados.     |
| Objetivo do Teste | O sistema deve verificar se o e-mail e senha estão cadastrados. |
| Passos | 	1. Entrar na página Login; 2. preencher o e-mail e senha obrigatório; 3. clicar no botão Login; 4. Verificar se uma mensagem de sucesso é exibida e se o usuário é redirecionado para a página de perfil.   |
| Critérios de êxito | O sistema deve exibir uma mensagem confirmando que o Login foi realizado. |
| Responsável pela elaborar do caso de Teste | Larissa Moreira |

|Caso de Teste    | CT-03– Redefinição de senha |
|:---|:---|
| Requisitos Associados | RF-03– Redefinição de senha.    |
| Objetivo do Teste | O sistema deve verificar se o e-mail já está cadastrado. |
| Passos | 1. Entrar na página Redefinir Senha; 2. preencher o e-mail cadastrado; 3. clicar no botão Redefinir senha; 4. Verificar se uma mensagem de sucesso é exibida e se um e-mail para redefinir senha é enviado ao usuário.  |
| Critérios de êxito | O sistema deve exibir uma mensagem “E-mail para redefinir senha enviado”.  |
| Responsável pela elaborar do caso de Teste | Nicolas Gabriel |

|Caso de Teste    | CT-04– Registro de refeições |
|:---|:---|
| Requisitos Associados | RF-04– Registro de refeições	    |
| Objetivo do Teste | O sistema deve registrar as refeições. |
| Passos | 1. Entrar na página Refeições 2. Clicar em "Adicionar"; 3. Preencher os campos; 4. Clicar em "Create"  |
| Critérios de êxito | O sistema deve armazenar a refeição no banco de dados.  |
| Responsável pela elaborar do caso de Teste | Letícia Moreira |

|Caso de Teste    | CT-05– Cálculo de nutrientes |
|:---|:---|
| Requisitos Associados | RF-05– Cálculo de nutrientes 	    |
| Objetivo do Teste | O sistema deve calcular o valor nutricional da refeição. |
| Passos | 1. Registrar refeição 2. Sistema mostrar os valores nutricionais da refeição;  |
| Critérios de êxito | O sistema deve armazenar a refeição no banco de dados.  |
| Responsável pela elaborar do caso de Teste |  |

|Caso de Teste    | CT-06– Gerar relatórios de consumo	 |
|:---|:---|
| Requisitos Associados | RF-06– Gerar relatórios de consumo	 	    |
| Objetivo do Teste | Sistema deve gerar um relatorio das refeições do mês |
| Passos |  |
| Critérios de êxito | O sistema deve gerar um relatorio mensal.  |
| Responsável pela elaborar do caso de Teste | Junio Flausino |

|Caso de Teste    | CT-07– Dicas nutricionais		 |
|:---|:---|
| Requisitos Associados | RF-07– Dicas nutricionais	 	    |
| Objetivo do Teste | Deve ser possivel cadastrar Dicas. |
| Passos | 1. Clicar em "Dicas Nutricionais" 2. Preencha os campos. 3. Clique em "Salvar" |
| Critérios de êxito | Sistema deve cadastrar as dicas.  |
| Responsável pela elaborar do caso de Teste | Felipe Soares  |

|Caso de Teste    | CT-08– Permitir o usuário criar metas e acompanhar o progresso			 |
|:---|:---|
| Requisitos Associados | RF-08– Permitir o usuário criar metas e acompanhar o progresso	 	    |
| Objetivo do Teste | Cadastrar Metas e acompanhar as metas |
| Passos | 1. Clicar em "Metas" 2. Preencha os campos. 3. Clique em "Create" |
| Critérios de êxito | Sistema deve cadastrar as metas.  |
| Responsável pela elaborar do caso de Teste | Daianne Paula  |

|Caso de Teste    | CT-09– Perfil do usuário com informações importantes como alergias.			 |
|:---|:---|
| Requisitos Associados | RF-09– Perfil do usuário com informações importantes como alergias.	 	    |
| Objetivo do Teste | Ter uma pagina com informações do usuario |
| Passos | 1. Realizar Login 2. Clicar no seu nome no canto superior direito   |
| Critérios de êxito | Exibir informações pessoais do usuario  |
| Responsável pela elaborar do caso de Teste | Larissa Moreira  |

|Caso de Teste    | CT-10– Permitir a criação de notas em cada relatório				 |
|:---|:---|
| Requisitos Associados | RF-10– Permitir a criação de notas em cada relatório.	 	    |
| Objetivo do Teste | Realizar comentarios nos relatorios |
| Passos |    |
| Critérios de êxito | O nutricionista conseguir realizar comentarios no relatorio para o Paciente ver |
| Responsável pela elaborar do caso de Teste | Felipe Soares  |

|Caso de Teste    | CT-11– Avaliar dicas nutricionais.			 |
|:---|:---|
| Requisitos Associados | RF-11– Avaliar dicas nutricionais.	 	    |
| Objetivo do Teste | Realizar avaliação das dicas postadas |
| Passos | 1. Realizar Login 2. Clicar em "Dicas Nutricionais" 3. Clicar em "like" ou "deslike"   |
| Critérios de êxito | Avaliar as dicas e aumentar o contador com seu clique  |
| Responsável pela elaborar do caso de Teste | Nicolas Gabriel |




















