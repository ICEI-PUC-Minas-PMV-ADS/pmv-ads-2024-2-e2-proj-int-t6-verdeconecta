IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027005326_M01TableUsuarios'
)
BEGIN
    CREATE TABLE [Usuario] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [DataDeNascimento] datetime2 NOT NULL,
        [Peso] real NOT NULL,
        [Altura] real NOT NULL,
        [Senha] nvarchar(max) NOT NULL,
        [Perfil] int NOT NULL,
        CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027005326_M01TableUsuarios'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241027005326_M01TableUsuarios', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027175716_M02TableAlimentoseRefeicoes'
)
BEGIN
    CREATE TABLE [Refeicao] (
        [Id] int NOT NULL IDENTITY,
        [TipoRefeicao] int NOT NULL,
        [fibras] real NOT NULL,
        [proteinas] real NOT NULL,
        [carboidratos] real NOT NULL,
        [gorduras] real NOT NULL,
        [calorias] real NOT NULL,
        [DataDaRefeicao] datetime2 NOT NULL,
        CONSTRAINT [PK_Refeicao] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027175716_M02TableAlimentoseRefeicoes'
)
BEGIN
    CREATE TABLE [Alimento] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NOT NULL,
        [gramas] int NOT NULL,
        [fibras] real NOT NULL,
        [proteinas] real NOT NULL,
        [carboidratos] real NOT NULL,
        [gorduras] real NOT NULL,
        [calorias] real NOT NULL,
        [RefeicaoId] int NULL,
        CONSTRAINT [PK_Alimento] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Alimento_Refeicao_RefeicaoId] FOREIGN KEY ([RefeicaoId]) REFERENCES [Refeicao] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027175716_M02TableAlimentoseRefeicoes'
)
BEGIN
    CREATE INDEX [IX_Alimento_RefeicaoId] ON [Alimento] ([RefeicaoId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027175716_M02TableAlimentoseRefeicoes'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241027175716_M02TableAlimentoseRefeicoes', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027180248_M03AtualizacaoTabelaRefeicoes'
)
BEGIN
    ALTER TABLE [Alimento] DROP CONSTRAINT [FK_Alimento_Refeicao_RefeicaoId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027180248_M03AtualizacaoTabelaRefeicoes'
)
BEGIN
    EXEC sp_rename N'[Refeicao].[proteinas]', N'Proteinas', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027180248_M03AtualizacaoTabelaRefeicoes'
)
BEGIN
    EXEC sp_rename N'[Refeicao].[gorduras]', N'Gorduras', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027180248_M03AtualizacaoTabelaRefeicoes'
)
BEGIN
    EXEC sp_rename N'[Refeicao].[fibras]', N'Fibras', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027180248_M03AtualizacaoTabelaRefeicoes'
)
BEGIN
    EXEC sp_rename N'[Refeicao].[carboidratos]', N'Carboidratos', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027180248_M03AtualizacaoTabelaRefeicoes'
)
BEGIN
    EXEC sp_rename N'[Refeicao].[calorias]', N'Calorias', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027180248_M03AtualizacaoTabelaRefeicoes'
)
BEGIN
    EXEC sp_rename N'[Alimento].[RefeicaoId]', N'AlimentoId', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027180248_M03AtualizacaoTabelaRefeicoes'
)
BEGIN
    EXEC sp_rename N'[Alimento].[IX_Alimento_RefeicaoId]', N'IX_Alimento_AlimentoId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027180248_M03AtualizacaoTabelaRefeicoes'
)
BEGIN
    ALTER TABLE [Alimento] ADD CONSTRAINT [FK_Alimento_Refeicao_AlimentoId] FOREIGN KEY ([AlimentoId]) REFERENCES [Refeicao] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027180248_M03AtualizacaoTabelaRefeicoes'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241027180248_M03AtualizacaoTabelaRefeicoes', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    ALTER TABLE [Alimento] DROP CONSTRAINT [FK_Alimento_Refeicao_AlimentoId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    DROP INDEX [IX_Alimento_AlimentoId] ON [Alimento];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Alimento]') AND [c].[name] = N'AlimentoId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Alimento] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Alimento] DROP COLUMN [AlimentoId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    EXEC sp_rename N'[Alimento].[proteinas]', N'Proteinas', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    EXEC sp_rename N'[Alimento].[gramas]', N'Gramas', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    EXEC sp_rename N'[Alimento].[gorduras]', N'Gorduras', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    EXEC sp_rename N'[Alimento].[fibras]', N'Fibras', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    EXEC sp_rename N'[Alimento].[carboidratos]', N'Carboidratos', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    EXEC sp_rename N'[Alimento].[calorias]', N'Calorias', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    ALTER TABLE [Refeicao] ADD [AlimentoId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    ALTER TABLE [Refeicao] ADD [UsuarioId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    CREATE INDEX [IX_Refeicao_AlimentoId] ON [Refeicao] ([AlimentoId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    CREATE INDEX [IX_Refeicao_UsuarioId] ON [Refeicao] ([UsuarioId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    ALTER TABLE [Refeicao] ADD CONSTRAINT [FK_Refeicao_Alimento_AlimentoId] FOREIGN KEY ([AlimentoId]) REFERENCES [Alimento] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    ALTER TABLE [Refeicao] ADD CONSTRAINT [FK_Refeicao_Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241027192810_M05TableAlimentosRefeicoesUsuarioForeingKeys', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027212406_M06CorrigeatributoTabelaRefeicao'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Refeicao]') AND [c].[name] = N'Calorias');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Refeicao] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Refeicao] DROP COLUMN [Calorias];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027212406_M06CorrigeatributoTabelaRefeicao'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Refeicao]') AND [c].[name] = N'Carboidratos');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Refeicao] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Refeicao] DROP COLUMN [Carboidratos];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027212406_M06CorrigeatributoTabelaRefeicao'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Refeicao]') AND [c].[name] = N'Fibras');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Refeicao] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Refeicao] DROP COLUMN [Fibras];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027212406_M06CorrigeatributoTabelaRefeicao'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Refeicao]') AND [c].[name] = N'Gorduras');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Refeicao] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Refeicao] DROP COLUMN [Gorduras];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027212406_M06CorrigeatributoTabelaRefeicao'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Refeicao]') AND [c].[name] = N'Proteinas');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Refeicao] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Refeicao] DROP COLUMN [Proteinas];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027212406_M06CorrigeatributoTabelaRefeicao'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241027212406_M06CorrigeatributoTabelaRefeicao', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241101132935_M07DicasNutricionais'
)
BEGIN
    CREATE TABLE [DicasNutricionais] (
        [Id] int NOT NULL IDENTITY,
        [Titulo] nvarchar(max) NOT NULL,
        [Dica] nvarchar(max) NOT NULL,
        [DataDica] datetime2 NOT NULL,
        CONSTRAINT [PK_DicasNutricionais] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241101132935_M07DicasNutricionais'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241101132935_M07DicasNutricionais', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241113191154_AdicionarLikesDislikes'
)
BEGIN
    ALTER TABLE [DicasNutricionais] ADD [Dislikes] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241113191154_AdicionarLikesDislikes'
)
BEGIN
    ALTER TABLE [DicasNutricionais] ADD [Likes] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241113191154_AdicionarLikesDislikes'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241113191154_AdicionarLikesDislikes', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241118004951_m08'
)
BEGIN
    ALTER TABLE [Usuario] ADD [TokenRedefinicaoSenha] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241118004951_m08'
)
BEGIN
    ALTER TABLE [Usuario] ADD [TokenValidade] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241118004951_m08'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241118004951_m08', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241121131110_M09CorrigirMetas'
)
BEGIN
    CREATE TABLE [Meta] (
        [IDMe] int NOT NULL IDENTITY,
        [DaraCriacao] datetime2 NOT NULL,
        [duracaoDaMeta] datetime2 NOT NULL,
        [metaCalorica] real NOT NULL,
        [MetaFibras] real NOT NULL,
        [metaProteinas] real NOT NULL,
        [metaCarboidratos] real NOT NULL,
        [metaSodio] real NOT NULL,
        [metaGorduraTotais] real NOT NULL,
        [idUsuario] int NOT NULL,
        CONSTRAINT [PK_Meta] PRIMARY KEY ([IDMe]),
        CONSTRAINT [FK_Meta_Usuario_idUsuario] FOREIGN KEY ([idUsuario]) REFERENCES [Usuario] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241121131110_M09CorrigirMetas'
)
BEGIN
    CREATE INDEX [IX_Meta_idUsuario] ON [Meta] ([idUsuario]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241121131110_M09CorrigirMetas'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241121131110_M09CorrigirMetas', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241121235451_M10'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241121235451_M10', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241123215451_M11TabelaRelacionamentoNutricionistaCliente'
)
BEGIN
    CREATE TABLE [RelacionamentoNutricionistaCliente] (
        [IdNutricionista] int NOT NULL,
        [IdCliente] int NOT NULL,
        CONSTRAINT [PK_RelacionamentoNutricionistaCliente] PRIMARY KEY ([IdNutricionista], [IdCliente]),
        CONSTRAINT [FK_RelacionamentoNutricionistaCliente_Usuario_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Usuario] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_RelacionamentoNutricionistaCliente_Usuario_IdNutricionista] FOREIGN KEY ([IdNutricionista]) REFERENCES [Usuario] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241123215451_M11TabelaRelacionamentoNutricionistaCliente'
)
BEGIN
    CREATE INDEX [IX_RelacionamentoNutricionistaCliente_IdCliente] ON [RelacionamentoNutricionistaCliente] ([IdCliente]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241123215451_M11TabelaRelacionamentoNutricionistaCliente'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241123215451_M11TabelaRelacionamentoNutricionistaCliente', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241124195436_M12Addrelacaousuarioquestionario'
)
BEGIN
    CREATE TABLE [Questionarios] (
        [Id] int NOT NULL IDENTITY,
        [TipoDieta] int NULL,
        [TemRestricaoAlimentar] bit NOT NULL,
        [RestricaoDetalhes] nvarchar(max) NULL,
        [NivelAtividadeFisica] int NOT NULL,
        [ObjetivoPrincipal] int NOT NULL,
        [RefeicoesPorDia] int NOT NULL,
        [HorarioRefeicoes] nvarchar(max) NULL,
        [ConsumoFrutasVegetais] int NOT NULL,
        [UsuarioId] int NOT NULL,
        CONSTRAINT [PK_Questionarios] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Questionarios_Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241124195436_M12Addrelacaousuarioquestionario'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Questionarios_UsuarioId] ON [Questionarios] ([UsuarioId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241124195436_M12Addrelacaousuarioquestionario'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241124195436_M12Addrelacaousuarioquestionario', N'8.0.11');
END;
GO

COMMIT;
GO

