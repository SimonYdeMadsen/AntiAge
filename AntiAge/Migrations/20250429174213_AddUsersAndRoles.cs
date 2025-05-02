using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bio_age_factors",
                schema: "identity",
                columns: table => new
                {
                    factor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    factor_name = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    weight_coefficient = table.Column<decimal>(type: "decimal(6,3)", nullable: true),
                    unit_of_measure = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    optimal_range_min = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    optimal_range_max = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bio_age___21172E73552A6FD2", x => x.factor_id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                schema: "identity",
                columns: table => new
                {
                    exercise_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exercise_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    muscle_group = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    equipment_needed = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    difficulty_level = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    demo_video_url = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Exercise__C121418E8D0E14E0", x => x.exercise_id);
                });

            migrationBuilder.CreateTable(
                name: "Health_goals",
                schema: "identity",
                columns: table => new
                {
                    goal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    goal_type = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    target_value = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    start_date = table.Column<DateOnly>(type: "date", nullable: true),
                    target_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Health_g__76679A2438B8684E", x => x.goal_id);
                });

            migrationBuilder.CreateTable(
                name: "Health_metrics",
                schema: "identity",
                columns: table => new
                {
                    metric_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    date_recorded = table.Column<DateOnly>(type: "date", nullable: true),
                    weight_kg = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    body_fat_percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    bmi = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    blood_pressure_systolic = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    blood_pressure_diastolic = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    resting_heart_rate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    blood_glucose = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    hdl_cholesterol = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ldl_cholesterol = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    triglycerides = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    vo2_max = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    sleep_hours = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    steps_count = table.Column<int>(type: "int", nullable: true),
                    biological_age = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Health_m__13D5DCA401952E8C", x => x.metric_id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe_Ingredients",
                schema: "identity",
                columns: table => new
                {
                    recipe_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ingredient_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    unit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recipe_I__3571ED9BB9A5E195", x => x.recipe_id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                schema: "identity",
                columns: table => new
                {
                    recipe_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    preparation_time = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    cooking_time = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    servings = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    calories_per_serving = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    protein_grams = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    carbs_grams = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    fat_grams = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    recipe_category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    instructions = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recipes__3571ED9BEF8B1603", x => x.recipe_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeightCm = table.Column<short>(type: "smallint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Workout_exercises",
                schema: "identity",
                columns: table => new
                {
                    workout_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exercise_id = table.Column<int>(type: "int", nullable: true),
                    sets = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    repeats = table.Column<int>(type: "int", nullable: true),
                    repeats_units = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    rest_period = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    sequence_number = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Workout___02AB2F8EDEA9C95B", x => x.workout_id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                schema: "identity",
                columns: table => new
                {
                    workout_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    program_id = table.Column<int>(type: "int", nullable: true),
                    workout_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    week_number = table.Column<int>(type: "int", nullable: true),
                    day_number = table.Column<int>(type: "int", nullable: true),
                    estimated_duration = table.Column<int>(type: "int", nullable: true),
                    instructions = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Workouts__02AB2F8EDA7925F0", x => x.workout_id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts_logs",
                schema: "identity",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    workout_id = table.Column<int>(type: "int", nullable: true),
                    date_completed = table.Column<DateOnly>(type: "date", nullable: true),
                    duration_minutes = table.Column<int>(type: "int", nullable: true),
                    perceived_effort = table.Column<int>(type: "int", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Workouts__9E2397E094655130", x => x.log_id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts_programs",
                schema: "identity",
                columns: table => new
                {
                    program_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    program_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    difficulty_level = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    duration_weeks = table.Column<int>(type: "int", nullable: true),
                    focus_area = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Workouts__3A7890AC2210279F", x => x.program_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "identity",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "identity",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "identity",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "identity",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "identity",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Bio_age_factors",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Exercises",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Health_goals",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Health_metrics",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Recipe_Ingredients",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Recipes",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Workout_exercises",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Workouts",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Workouts_logs",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Workouts_programs",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "identity");
        }
    }
}
