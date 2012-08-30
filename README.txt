EFActiveRecord é um modelo de implementação do Partner utilizando recursos do Entity Framework. 

Para entender o funcionamento da biblioteca acesse a pasta repositorio e veja os arquivos contidos nela, depois veja a implementação no modelo e posteriormente no Controller.

Quer entender mais  sobre o Active Record leia o texto abaixo:


Em Engenharia de software, active record é um padrão de projeto encontrado em softwares que armazenam seus dados em Banco de dados relacionais. Assim foi nomeado por Martin Fowler em seu livro Patterns of Enterprise Application Architecture[1]. A interface de um certo objeto deve incluir funções como por exemplo Inserir(Insert), Atualizar(Update), Apagar(Delete) e propriedades que correspondam de certa forma diretamente às colunas do banco de dados associado.
Active record é uma abordagem para acesso de dados num banco de dados. Uma tabela de banco de dados ou visão(view) é embrulhada(wrapped) em uma classe. Portanto, uma instância de um objeto é amarrada a um único registo(tupla) na tabela. Após a criação e gravação de um objeto, um novo registo é adicionado à tabela. Qualquer objeto carregado obtém suas informações a partir do banco de dados. Quando um objeto é atualizado, o registro correspondente na tabela também é atualizado. A classe de embrulho implementa os métodos de acesso(setter e getter) ou propriedades para cada coluna na tabela ou visão.

fonte: http://pt.wikipedia.org/wiki/Active_record