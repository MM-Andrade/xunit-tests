﻿namespace UnitTestMoq.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Preco { get; set; }
        public int QtdeEstoque { get; set; }
    }
}