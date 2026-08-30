using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace To_Do_List.Models;

public partial class ToDoListContext : DbContext
{
    public ToDoListContext()
    {
    }

    public ToDoListContext(DbContextOptions<ToDoListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblTask> TblTasks { get; set; }

    public virtual DbSet<TblTeam> TblTeams { get; set; }

    public virtual DbSet<TblTeamTask> TblTeamTasks { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tbl_Cate__6DB38D6EA1CFE59F");

            entity.ToTable("tbl_Category");

            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CategoryName)
                .IsUnicode(false)
                .HasColumnName("Category_Name");
            entity.Property(e => e.User)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.TblCategories)
                .HasForeignKey(d => d.User)
                .HasConstraintName("fk_Category_User");
        });

        modelBuilder.Entity<TblTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__tbl_Task__716F4AED2479F05D");

            entity.ToTable("tbl_Tasks");

            entity.Property(e => e.TaskId).HasColumnName("Task_Id");
            entity.Property(e => e.CompletedDate).HasColumnName("Completed_Date");
            entity.Property(e => e.TaskCategory).HasColumnName("Task_Category");
            entity.Property(e => e.TaskDate).HasColumnName("Task_Date");
            entity.Property(e => e.TaskDiscription)
                .IsUnicode(false)
                .HasColumnName("Task_Discription");
            entity.Property(e => e.TaskTime).HasColumnName("Task_Time");
            entity.Property(e => e.TaskTitle)
                .IsUnicode(false)
                .HasColumnName("Task_Title");
            entity.Property(e => e.TaskUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Task_User");

            entity.HasOne(d => d.TaskCategoryNavigation).WithMany(p => p.TblTasks)
                .HasForeignKey(d => d.TaskCategory)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_Task_Category");

            entity.HasOne(d => d.TaskUserNavigation).WithMany(p => p.TblTasks)
                .HasForeignKey(d => d.TaskUser)
                .HasConstraintName("fk_Task_User");
        });

        modelBuilder.Entity<TblTeam>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__tbl_Team__F82DEDBC5DED588A");

            entity.ToTable("tbl_Teams");

            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.MembersNum).HasColumnName("members_num");
            entity.Property(e => e.TeamAdmin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("team_admin");
            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("team_name");
        });

        modelBuilder.Entity<TblTeamTask>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PK__tbl_Team__E579775F4F98DA08");

            entity.ToTable("tbl_TeamTasks");

            entity.Property(e => e.TId).HasColumnName("t_id");
            entity.Property(e => e.TCompletedDate).HasColumnName("t_CompletedDate");
            entity.Property(e => e.TDate).HasColumnName("t_Date");
            entity.Property(e => e.TDiscription)
                .IsUnicode(false)
                .HasColumnName("t_discription");
            entity.Property(e => e.TStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("t_status");
            entity.Property(e => e.TTime).HasColumnName("t_Time");
            entity.Property(e => e.TTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("t_title");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserEmail);

            entity.ToTable("tbl_User", tb => tb.HasTrigger("trigger_DeleteUserCategory"));

            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("User_Email");
            entity.Property(e => e.ConfirmPassword)
                .IsUnicode(false)
                .HasColumnName("Confirm_Password");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("User_Name");
            entity.Property(e => e.UserPassword)
                .IsUnicode(false)
                .HasColumnName("User_Password");
            entity.Property(e => e.UserPhone).HasColumnName("User_Phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
