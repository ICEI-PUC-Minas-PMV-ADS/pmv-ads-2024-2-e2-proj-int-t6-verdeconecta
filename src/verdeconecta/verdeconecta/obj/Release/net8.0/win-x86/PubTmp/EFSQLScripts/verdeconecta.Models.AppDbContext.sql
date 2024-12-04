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
    WHERE [MigrationId] = N'20241203210002_m01'
)
BEGIN
    CREATE TABLE [Alimento] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NOT NULL,
        [Fibras] real NOT NULL,
        [Proteinas] real NOT NULL,
        [Carboidratos] real NOT NULL,
        [Gorduras] real NOT NULL,
        [Calorias] real NOT NULL,
        CONSTRAINT [PK_Alimento] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241203210002_m01'
)
BEGIN
    CREATE TABLE [DicasNutricionais] (
        [Id] int NOT NULL IDENTITY,
        [Titulo] nvarchar(max) NOT NULL,
        [Dica] nvarchar(max) NOT NULL,
        [DataDica] datetime2 NOT NULL,
        [Likes] int NOT NULL,
        [Dislikes] int NOT NULL,
        CONSTRAINT [PK_DicasNutricionais] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241203210002_m01'
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
        [TokenRedefinicaoSenha] nvarchar(max) NULL,
        [TokenValidade] datetime2 NULL,
        CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241203210002_m01'
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
    WHERE [MigrationId] = N'20241203210002_m01'
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
    WHERE [MigrationId] = N'20241203210002_m01'
)
BEGIN
    CREATE TABLE [Refeicao] (
        [Id] int NOT NULL IDENTITY,
        [TipoRefeicao] int NOT NULL,
        [DataDaRefeicao] datetime2 NOT NULL,
        [Quantidade] real NOT NULL,
        [AlimentoId] int NOT NULL,
        [UsuarioId] int NOT NULL,
        CONSTRAINT [PK_Refeicao] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Refeicao_Alimento_AlimentoId] FOREIGN KEY ([AlimentoId]) REFERENCES [Alimento] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Refeicao_Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241203210002_m01'
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
    WHERE [MigrationId] = N'20241203210002_m01'
)
BEGIN
    CREATE INDEX [IX_Meta_idUsuario] ON [Meta] ([idUsuario]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241203210002_m01'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Questionarios_UsuarioId] ON [Questionarios] ([UsuarioId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241203210002_m01'
)
BEGIN
    CREATE INDEX [IX_Refeicao_AlimentoId] ON [Refeicao] ([AlimentoId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241203210002_m01'
)
BEGIN
    CREATE INDEX [IX_Refeicao_UsuarioId] ON [Refeicao] ([UsuarioId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241203210002_m01'
)
BEGIN
    CREATE INDEX [IX_RelacionamentoNutricionistaCliente_IdCliente] ON [RelacionamentoNutricionistaCliente] ([IdCliente]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241203210002_m01'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241203210002_m01', N'8.0.11');
END;
GO

COMMIT;
GO

