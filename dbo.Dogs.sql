﻿CREATE TABLE [dbo].[Dogs] (
    [Id]           INT        NOT NULL,
    [name]         NCHAR (30) NOT NULL,
    [pedigreeNr]   NCHAR (30) NULL,
    [tatovering]   NCHAR (30) NULL,
    [breeder]      NCHAR (30) NULL,
    [father]       NCHAR (30) NULL,
    [mother]       NCHAR (30) NULL,
    [dkktitler]    NCHAR (30) NULL,
    [titler]       NCHAR (30) NULL,
    [lastvisit]    NCHAR (10) NULL,
    [count]        NCHAR (10) NULL,
    [born]         DATE       NULL,
    [HD]           NCHAR (30) NULL,
    [HeartInfo]    NCHAR (30) NULL,
    [BackInfo]     NCHAR (30) NULL,
    [SP]           NCHAR (30) NULL,
    [indexdato]    DATE       NULL,
    [HDindex]      FLOAT (53) NULL,
    [sex]          NCHAR (1)  NULL,
    [farve]        NCHAR (30) NULL,
    [dead]         INT        NULL,
    [AK]           NCHAR (30) NULL,
    [avlsstatus]   NCHAR (30) NULL,
    [mb]           NCHAR (30) NULL,
    [billede]      NCHAR (30) NULL,
    [ejer]         NCHAR (30) NULL,
    [addresse]     NCHAR (30) NULL,
    [postnr]       NCHAR (30) NULL,
    [by]           NCHAR (30) NULL,
    [telefon]      NCHAR (30) NULL,
    [email]        NCHAR (30) NULL,
    [url]          NCHAR (30) NULL,
    [log]          NCHAR (30) NULL,
    [brugernavn]   NCHAR (30) NULL,
    [password]     NCHAR (30) NULL,
    [updated]      DATE       NULL,
    [brugercookie] NCHAR (30) NULL,
    [brugerip]     NCHAR (30) NULL,
    [addedby]      NCHAR (30) NULL,
    [dateadded]    DATE       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

