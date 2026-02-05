CREATE TYPE RoleUtilisateur AS ENUM (
  'MEMBRE_UNITE',
  'CHEF_UNITE',
  'DIRECTEUR_UNITES',
  'DIRECTEUR_GENERAL',
  'ADMINISTRATEUR'
);

CREATE TYPE CanalNotification AS ENUM (
  'PushMobile',
  'Email',
  'Sms',
  'OneSignal'
);

CREATE TYPE TypeNotification AS ENUM (
  'Actionnable',
  'LectureSeule',
  'Escalade'
);

CREATE TYPE Criticite AS ENUM (
  'CRITIQUE',
  'HAUTE',
  'MOYENNE',
  'BASSE',
  'INFO'
);

CREATE TYPE NiveauEscalade AS ENUM (
  'NIVEAU_0',
  'NIVEAU_1',
  'NIVEAU_2'
);

CREATE TYPE StatutAlert AS ENUM (
  'NOUVELLE',
  'NOTIFIEE',
  'EN_COURS',
  'ESCALADE_N1',
  'EN_COURS_N1',
  'ESCALADE_N2',
  'EN_COURS_N2',
  'RESOLUE',
  'FERMEE'
);

CREATE TYPE TypeAlerte AS ENUM (
  'INCIDENT',
  'WARNING',
  'ERROR',
  'PERFORMANCE',
  'SECURITY',
  'AVAILABILITY'
);

CREATE TABLE "User" (
  Id BIGSERIAL PRIMARY KEY,
  Nom VARCHAR(150),
  Prenom VARCHAR(150),
  Email VARCHAR(200) UNIQUE,
  Telephone VARCHAR(50),
  MotDePasseHash TEXT,
  Role RoleUtilisateur,
  Actif BOOLEAN,
  DateCreation TIMESTAMP,
  DateModification TIMESTAMP
);

CREATE TABLE "Alerte" (
  Id BIGSERIAL PRIMARY KEY,
  Titre VARCHAR(255),
  Description TEXT,
  TypeAlerte TypeAlerte,
  Criticite Criticite,
  StatutAlert StatutAlert,
  NiveauEscaladeActuel NiveauEscalade,
  DateCreation TIMESTAMP,
  DateNotification TIMESTAMP,
  DateEscaladeN1 TIMESTAMP,
  DateEscaladeN2 TIMESTAMP,
  DatePriseEnCharge TIMESTAMP,
  DateResolution TIMESTAMP,
  Metadata TEXT,
  SourceId BIGINT,
  ResponsableActuel BIGINT,

  CONSTRAINT fk_alerte_source
    FOREIGN KEY (SourceId) REFERENCES "User"(Id),

  CONSTRAINT fk_alerte_responsable
    FOREIGN KEY (ResponsableActuel) REFERENCES "User"(Id)
);

CREATE TABLE "Notification" (
  Id BIGSERIAL PRIMARY KEY,
  AlertAlerte BIGINT,
  UtilisateurDestinataire BIGINT,
  TypeNotification TypeNotification,
  CanalNotification CanalNotification,
  Titre VARCHAR(255),
  Message TEXT,
  Priorite INT,
  Envoyee BOOLEAN,
  Lue BOOLEAN,
  DateEnvoi TIMESTAMP,
  DateLecture TIMESTAMP,
  Metadata TEXT,

  CONSTRAINT fk_notification_alerte
    FOREIGN KEY (AlertAlerte) REFERENCES "Alerte"(Id),

  CONSTRAINT fk_notification_user
    FOREIGN KEY (UtilisateurDestinataire) REFERENCES "User"(Id)
);

CREATE TABLE "Historique" (
  Id BIGSERIAL PRIMARY KEY,
  AlertAlerte BIGINT,
  UtilisateurUtilisateur BIGINT,
  Action VARCHAR(255),
  StatutAlerteAncienStatut StatutAlert,
  StatutAlerteNouveauStatut StatutAlert,
  Commentaire TEXT,
  DateAction TIMESTAMP,
  Metadata TEXT,

  CONSTRAINT fk_historique_alerte
    FOREIGN KEY (AlertAlerte) REFERENCES "Alerte"(Id),

  CONSTRAINT fk_historique_user
    FOREIGN KEY (UtilisateurUtilisateur) REFERENCES "User"(Id)
);

CREATE TABLE "ConfigurationEscalade" (
  Id BIGSERIAL PRIMARY KEY,
  DelaiNiveau1VersNiveau2 INT,
  DelaiNiveau0VersNiveau1 INT,
  FrequenceVerification INT,
  NombreRappelsMax INT,
  IntervalleRappel INT,
  NotificationId BIGINT,

  CONSTRAINT fk_config_notification
    FOREIGN KEY (NotificationId) REFERENCES "Notification"(Id)
);

CREATE TABLE "Escalade" (
  Id BIGSERIAL PRIMARY KEY,
  AlertAlerte BIGINT,
  NiveauEscaladeNiveauDepart NiveauEscalade,
  NiveauEscaladeNiveauArrivee NiveauEscalade,
  DeclenchementAutomatique BOOLEAN,
  Raison TEXT,
  DateEscalade TIMESTAMP,
  NotificationId BIGINT,

  CONSTRAINT fk_escalade_alerte
    FOREIGN KEY (AlertAlerte) REFERENCES "Alerte"(Id),

  CONSTRAINT fk_escalade_notification
    FOREIGN KEY (NotificationId) REFERENCES "Notification"(Id)
);

CREATE TABLE "RegleEscalade" (
  Id BIGSERIAL PRIMARY KEY,
  Nom VARCHAR(200),
  TypeAlerte TypeAlerte,
  Criticite Criticite,
  NiveauEscaladeSource NiveauEscalade,
  NiveauEscaladeCible NiveauEscalade,
  DelaiAvantEscalade INT,
  Active BOOLEAN
);

CREATE TABLE "Planificateur" (
  Id BIGSERIAL PRIMARY KEY,
  IntervalVerification INT,
  Actif BOOLEAN,
  DerniereExecution TIMESTAMP
);
