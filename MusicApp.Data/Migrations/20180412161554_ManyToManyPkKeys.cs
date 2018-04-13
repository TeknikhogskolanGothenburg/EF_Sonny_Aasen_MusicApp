using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MusicApp.Data.Migrations
{
    public partial class ManyToManyPkKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistSong",
                table: "ArtistSong");

            migrationBuilder.DropIndex(
                name: "IX_ArtistSong_ArtistId",
                table: "ArtistSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumSong",
                table: "AlbumSong");

            migrationBuilder.DropIndex(
                name: "IX_AlbumSong_AlbumId",
                table: "AlbumSong");

            migrationBuilder.DropColumn(
                name: "ArtistSongId",
                table: "ArtistSong");

            migrationBuilder.DropColumn(
                name: "AlbumSongId",
                table: "AlbumSong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistSong",
                table: "ArtistSong",
                columns: new[] { "ArtistId", "SongId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumSong",
                table: "AlbumSong",
                columns: new[] { "AlbumId", "SongId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistSong",
                table: "ArtistSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumSong",
                table: "AlbumSong");

            migrationBuilder.AddColumn<int>(
                name: "ArtistSongId",
                table: "ArtistSong",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "AlbumSongId",
                table: "AlbumSong",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistSong",
                table: "ArtistSong",
                column: "ArtistSongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumSong",
                table: "AlbumSong",
                column: "AlbumSongId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_ArtistId",
                table: "ArtistSong",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumSong_AlbumId",
                table: "AlbumSong",
                column: "AlbumId");
        }
    }
}
