// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YouLookGoodInPrint.Server.Data;

namespace YouLookGoodInPrint.Server.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20210523200048_db")]
    partial class db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2");

            modelBuilder.Entity("YouLookGoodInPrint.Server.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("YouLookGoodInPrint.Shared.Document", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("YouLookGoodInPrint.Shared.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DocumentTitle")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("PrintId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("YouLookGoodInPrint.Shared.Print", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<string>("DocId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Orientation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PrintDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Prints");
                });
#pragma warning restore 612, 618
        }
    }
}
