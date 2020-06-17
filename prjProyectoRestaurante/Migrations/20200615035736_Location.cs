using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace prjProyectoRestaurante.Migrations
{
    public partial class Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IDCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IDCategoria);
                });

            migrationBuilder.CreateTable(
                name: "EstadoMesa",
                columns: table => new
                {
                    IDEstado = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoMesa", x => x.IDEstado);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    IDGenero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sigla = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.IDGenero);
                });

            migrationBuilder.CreateTable(
                name: "InventarioIngrediente",
                columns: table => new
                {
                    IDInventarioIngre = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<decimal>(nullable: false),
                    CantidadMinima = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioIngrediente", x => x.IDInventarioIngre);
                });

            migrationBuilder.CreateTable(
                name: "InventarioProdu",
                columns: table => new
                {
                    IDIventaarioProdu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<decimal>(nullable: false),
                    CantidadMinima = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioProdu", x => x.IDIventaarioProdu);
                });

            migrationBuilder.CreateTable(
                name: "ReservaMesa",
                columns: table => new
                {
                    IDReservaMesa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(maxLength: 11, nullable: true),
                    HoraReserva = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaMesa", x => x.IDReservaMesa);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IDPersona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cedula = table.Column<string>(maxLength: 11, nullable: true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    ApellidoPa = table.Column<string>(maxLength: 50, nullable: true),
                    ApellidoMa = table.Column<string>(maxLength: 50, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 50, nullable: true),
                    TelefonoCel = table.Column<string>(maxLength: 11, nullable: true),
                    TelefonoDom = table.Column<string>(maxLength: 11, nullable: true),
                    Usuario = table.Column<string>(maxLength: 11, nullable: true),
                    Contraseña = table.Column<string>(maxLength: 11, nullable: true),
                    IDGenero = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IDPersona);
                    table.ForeignKey(
                        name: "FK_Persona_Genero_IDGenero",
                        column: x => x.IDGenero,
                        principalTable: "Genero",
                        principalColumn: "IDGenero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    IDIngrediente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    IDInventarioIngre = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.IDIngrediente);
                    table.ForeignKey(
                        name: "FK_Ingrediente_InventarioIngrediente_IDInventarioIngre",
                        column: x => x.IDInventarioIngre,
                        principalTable: "InventarioIngrediente",
                        principalColumn: "IDInventarioIngre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IDProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    Costo = table.Column<decimal>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    IDCategoria = table.Column<int>(nullable: true),
                    IDIventaarioProdu = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IDProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_IDCategoria",
                        column: x => x.IDCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IDCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_InventarioProdu_IDIventaarioProdu",
                        column: x => x.IDIventaarioProdu,
                        principalTable: "InventarioProdu",
                        principalColumn: "IDIventaarioProdu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    IDMesa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroMesa = table.Column<int>(nullable: false),
                    IDEstado = table.Column<int>(nullable: true),
                    IDReservaMesa = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.IDMesa);
                    table.ForeignKey(
                        name: "FK_Mesa_EstadoMesa_IDEstado",
                        column: x => x.IDEstado,
                        principalTable: "EstadoMesa",
                        principalColumn: "IDEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mesa_ReservaMesa_IDReservaMesa",
                        column: x => x.IDReservaMesa,
                        principalTable: "ReservaMesa",
                        principalColumn: "IDReservaMesa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relacion",
                columns: table => new
                {
                    IDRelacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    IDPersona = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relacion", x => x.IDRelacion);
                    table.ForeignKey(
                        name: "FK_Relacion_Persona_IDPersona",
                        column: x => x.IDPersona,
                        principalTable: "Persona",
                        principalColumn: "IDPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    IDOrden = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaOrden = table.Column<DateTime>(nullable: false),
                    IDMesa = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.IDOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Mesa_IDMesa",
                        column: x => x.IDMesa,
                        principalTable: "Mesa",
                        principalColumn: "IDMesa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IDRol = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    IDRelacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IDRol);
                    table.ForeignKey(
                        name: "FK_Rol_Relacion_IDRelacion",
                        column: x => x.IDRelacion,
                        principalTable: "Relacion",
                        principalColumn: "IDRelacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    IDFactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaFactura = table.Column<DateTime>(nullable: false),
                    IDPersona = table.Column<int>(nullable: true),
                    EstadoDeFactura = table.Column<string>(maxLength: 50, nullable: true),
                    Observacion = table.Column<string>(maxLength: 50, nullable: true),
                    IDOrden = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.IDFactura);
                    table.ForeignKey(
                        name: "FK_Factura_Orden_IDOrden",
                        column: x => x.IDOrden,
                        principalTable: "Orden",
                        principalColumn: "IDOrden",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Persona_IDPersona",
                        column: x => x.IDPersona,
                        principalTable: "Persona",
                        principalColumn: "IDPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoIngrediente",
                columns: table => new
                {
                    IDProduIng = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDProducto = table.Column<int>(nullable: true),
                    IDIngrediente = table.Column<int>(nullable: true),
                    IDOrden = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoIngrediente", x => x.IDProduIng);
                    table.ForeignKey(
                        name: "FK_ProductoIngrediente_Ingrediente_IDIngrediente",
                        column: x => x.IDIngrediente,
                        principalTable: "Ingrediente",
                        principalColumn: "IDIngrediente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoIngrediente_Orden_IDOrden",
                        column: x => x.IDOrden,
                        principalTable: "Orden",
                        principalColumn: "IDOrden",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoIngrediente_Producto_IDProducto",
                        column: x => x.IDProducto,
                        principalTable: "Producto",
                        principalColumn: "IDProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IDOrden",
                table: "Factura",
                column: "IDOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IDPersona",
                table: "Factura",
                column: "IDPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_IDInventarioIngre",
                table: "Ingrediente",
                column: "IDInventarioIngre");

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_IDEstado",
                table: "Mesa",
                column: "IDEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_IDReservaMesa",
                table: "Mesa",
                column: "IDReservaMesa");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IDMesa",
                table: "Orden",
                column: "IDMesa");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IDGenero",
                table: "Persona",
                column: "IDGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IDCategoria",
                table: "Producto",
                column: "IDCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IDIventaarioProdu",
                table: "Producto",
                column: "IDIventaarioProdu");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoIngrediente_IDIngrediente",
                table: "ProductoIngrediente",
                column: "IDIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoIngrediente_IDOrden",
                table: "ProductoIngrediente",
                column: "IDOrden");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoIngrediente_IDProducto",
                table: "ProductoIngrediente",
                column: "IDProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Relacion_IDPersona",
                table: "Relacion",
                column: "IDPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_IDRelacion",
                table: "Rol",
                column: "IDRelacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "ProductoIngrediente");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Relacion");

            migrationBuilder.DropTable(
                name: "InventarioIngrediente");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "InventarioProdu");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "EstadoMesa");

            migrationBuilder.DropTable(
                name: "ReservaMesa");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
