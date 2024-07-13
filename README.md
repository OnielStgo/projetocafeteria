# Sistema de vendas para uma cafeteria

## Comando para iniciar o projeto:
```
dotnet run
```

## Scripts para criar uma base de dados mock para testar o projeto:
```sql
CREATE DATABASE projetocafeteria;
USE projetocafeteria;

CREATE TABLE `pedido`(
    `idPedido` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `idCliente` INT UNSIGNED NOT NULL,
    `idFuncionario` INT UNSIGNED NOT NULL,
    `data` DATETIME NOT NULL,
    `total` DECIMAL(8, 2) NOT NULL
);
CREATE TABLE `funcionario`(
    `idFuncionario` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` VARCHAR(255) NOT NULL,
    `idade` VARCHAR(255) NOT NULL,
    `cpf` VARCHAR(255) NOT NULL,
    `telefone` VARCHAR(255) NOT NULL
);
CREATE TABLE `pedido_produto`(
    `idPed_Prod` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `idPedido` INT UNSIGNED NOT NULL,
    `idProduto` INT UNSIGNED NOT NULL,
    `quantidade` INT NOT NULL,
    `total` DECIMAL(8, 2) NOT NULL
);
CREATE TABLE `produto`(
    `idProduto` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `codigo` VARCHAR(255) NOT NULL,
    `descricao` VARCHAR(255) NOT NULL,
    `preco` DECIMAL(8, 2) NOT NULL
);
ALTER TABLE
    `produto` ADD UNIQUE `produto_codigo_unique`(`codigo`);
CREATE TABLE `cliente`(
    `idCliente` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` VARCHAR(255) NOT NULL,
    `idade` VARCHAR(255) NOT NULL,
    `cpf` VARCHAR(255) NOT NULL,
    `telefone` VARCHAR(255) NOT NULL
);
ALTER TABLE
    `pedido` ADD CONSTRAINT `pedido_idcliente_foreign` FOREIGN KEY(`idCliente`) REFERENCES `cliente`(`idCliente`);
ALTER TABLE
    `pedido_produto` ADD CONSTRAINT `pedido_produto_idpedido_foreign` FOREIGN KEY(`idPedido`) REFERENCES `pedido`(`idPedido`);
ALTER TABLE
    `pedido_produto` ADD CONSTRAINT `pedido_produto_idproduto_foreign` FOREIGN KEY(`idProduto`) REFERENCES `produto`(`idProduto`);
ALTER TABLE
    `pedido` ADD CONSTRAINT `pedido_idfuncionario_foreign` FOREIGN KEY(`idFuncionario`) REFERENCES `funcionario`(`idFuncionario`);
```

## Dados fake para colocar no banco de dados:
```sql
USE projetocafeteria;

INSERT INTO cliente (nome, idade, cpf, telefone) VALUES
('Ana Silva', '25', '123.456.789-01', '(11) 98765-4321'),
('Bruno Souza', '30', '234.567.890-12', '(21) 99876-5432');

INSERT INTO funcionario (nome, idade, cpf, telefone) VALUES
('Lucas Oliveira', '28', '112.233.445-56', '(11) 91234-5678'),
('Mariana Silva', '34', '223.344.556-67', '(21) 92345-6789');

INSERT INTO pedido (idCliente, idFuncionario, data, total) VALUES
('1', '1', '2023-01-05', '95.50'),
('2', '2', '2023-02-10', '75.00');

INSERT INTO produto (codigo, descricao, preco) VALUES
('4387', 'CAPUCCINO', '5.50'),
('4391', 'CAPUCCINO (CANELA)', '7');

INSERT INTO pedido_produto (idPedido, idProduto, quantidade, total) VALUES
('1', '2', '4', '28.00'),
('2', '1', '3', '16.50');
```