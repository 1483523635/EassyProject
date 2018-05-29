﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Web.Datas;
using Web.Infrastructure.Tools;

namespace Web.Datas.Migrations
{
    [DbContext(typeof(RepositoryDatabase))]
    partial class RepositoryDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web.Domains.EnterpriseEntity", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("AdultStatus");

                    b.Property<DateTime>("CreatTime");

                    b.Property<string>("EnterpriseIntroduce");

                    b.Property<string>("Name");

                    b.Property<string>("UserName");

                    b.HasKey("Key");

                    b.ToTable("EnterpriseEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
