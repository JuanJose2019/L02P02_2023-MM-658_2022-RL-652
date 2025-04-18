﻿using Microsoft.Identity.Client;
using System;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2023_MM_658_2022_RL_652.Models
{
    public class Clientes
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? email { get; set; }
        public string? direccion { get; set; }
        public DateTime? created_at { get; set; }
    }

    public class Autores
    {
        [Key]
        public int id { get; set; }
        public string? autor { get; set; }
    }

    public class Categorias
    {
        [Key]
        public int id { get; set; }
        public string? categoria { get; set; }
    }

    public class Libros
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public string? url_imagen { get; set; }
        public int id_autor { get; set; }
        public int id_categoria { get; set; }
        public decimal precio { get; set; }
        public char estado { get; set; }
    }

    public class pedido_encabezado
    {
        [Key]
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int cantidad_libros { get; set; }
        public decimal total { get; set; }
    }

    public class pedido_detalle
    {
        [Key]
        public int id { get; set; }
        public int id_pedido { get; set; }
        public int id_libro { get; set; }
        public DateTime created_at { get; set; }
    }

    public class comentarios_libros
    {
        [Key]
        public int id { get; set; }
        public int id_libro { get; set; }
        public string? comentarios { get; set; }
        public string? usuario { get; set; }
        public DateTime created_at { get; set; }
    }

    public class AutorLibrosViewModel
    {
        public Autores Autor { get; set; }
        public List<Libros> Libros { get; set; }
    }

    public class ComentariosViewModel
    {
        public Autores Autor { get; set; }
        public Libros Libro { get; set; }
        public List<comentarios_libros> Comentarios { get; set; }
    }

}
