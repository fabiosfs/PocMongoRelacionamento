# PocMongoRelacionamento

## Sobre o projeto
Este é projeto é uma Prova de conceito(POC) MongoDB utilizando queries relacionais.

Foi utilizado .net 6, para compilação é necessário que tenha o ambiente compilando projetos com esse framework.

Foi utilizado o MongoDB como base de dados afim de exemplificar uma query relacional de collections, você deve configurar no appsetings.json a string de conexão com sua base de dados mongo, neste exemplo estava utilizando uma base de dados local em um container docker.

## Ponto principal
O ponto principal de estudo desse projeto se encontra na classe CategoriaRepository:
```
var retorno = _collection.AsQueryable()
                .Where(x => true)
                .Join(
                    pessoaCollection.AsQueryable(),
                    categoria => categoria.IdPessoa,
                    pessoa => pessoa.Id,
                    (categoria, pessoa) => new CategoriaEntity(
                        categoria.Id,
                        categoria.IdPessoa,
                        categoria.Nome,
                        categoria.Descricao,
                        categoria.DataCriacao,
                        categoria.DataAtualizacao,
                        pessoa
                    )
                ).ToList();
```