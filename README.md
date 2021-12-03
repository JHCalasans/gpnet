O projeto contém tudo que foi pedido no pdf passado por email.

No projeto Xamarin foi utilizado o framework PRISM para a melhor utilização do padrão MVVM e navegação.

Além disso foi utilizado alguns plugins do nuget, como por exemplo o NewtonSoft para utilização de Json, e o Acr.Dialogs para melhor utilizar dialogs durante o uso do app.

A funcionalidade de 'Sincronizar' na tela principal irá enviar os dados cadastrados/alterados no app para o servidor(que está mantendo em memória assim como foi pedido).

São dois projetos separados, o projeto do aplicativo e o projeto contendo serviços REST(lembrando que para estes serviços funcionarem devem estar rodando em IIS).

IMPORTANTE - PARA PODER UTILIZAR OS SERVIÇOS REST A URL DEVE SER ALTERADA NA CLASSE 'VIEWMODELBASE' NO ATRIBUTO '_servidor', DEVE SER COLOCADO A URL ONDE O SERVIÇO ESTÁ PUBLICADO.  

