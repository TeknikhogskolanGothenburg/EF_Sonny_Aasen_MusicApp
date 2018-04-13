﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MusicApp.Data;
using System;

namespace MusicApp.Data.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20180412161554_ManyToManyPkKeys")]
    partial class ManyToManyPkKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicApp.Domain.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArtistId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicApp.Domain.AlbumSong", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<int>("SongId");

                    b.HasKey("AlbumId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("AlbumSong");
                });

            modelBuilder.Entity("MusicApp.Domain.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MusicApp.Domain.ArtistSong", b =>
                {
                    b.Property<int>("ArtistId");

                    b.Property<int>("SongId");

                    b.HasKey("ArtistId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("ArtistSong");
                });

            modelBuilder.Entity("MusicApp.Domain.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Length");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("MusicApp.Domain.Album", b =>
                {
                    b.HasOne("MusicApp.Domain.Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("MusicApp.Domain.AlbumSong", b =>
                {
                    b.HasOne("MusicApp.Domain.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MusicApp.Domain.Song", "Song")
                        .WithMany("Albums")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MusicApp.Domain.ArtistSong", b =>
                {
                    b.HasOne("MusicApp.Domain.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MusicApp.Domain.Song", "Song")
                        .WithMany("Artists")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
