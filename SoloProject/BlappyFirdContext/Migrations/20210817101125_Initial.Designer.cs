// <auto-generated />
using System;
using BlappyFirdContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlappyFirdContext.Migrations
{
    [DbContext(typeof(BFContext))]
    [Migration("20210817101125_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlappyFirdContext.Difficulty", b =>
                {
                    b.Property<int>("DifficultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("DifficultyId");

                    b.ToTable("Difficulty");
                });

            modelBuilder.Entity("BlappyFirdContext.Scores", b =>
                {
                    b.Property<int>("ScoresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HighestScore")
                        .HasColumnType("int");

                    b.Property<int>("RecentScore")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("ScoresId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("BlappyFirdContext.Users", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DifficultyId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScoresId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersId");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("ScoresId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlappyFirdContext.Users", b =>
                {
                    b.HasOne("BlappyFirdContext.Difficulty", "Difficulty")
                        .WithMany("Users")
                        .HasForeignKey("DifficultyId");

                    b.HasOne("BlappyFirdContext.Scores", "Scores")
                        .WithMany("Users")
                        .HasForeignKey("ScoresId");

                    b.Navigation("Difficulty");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("BlappyFirdContext.Difficulty", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BlappyFirdContext.Scores", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
