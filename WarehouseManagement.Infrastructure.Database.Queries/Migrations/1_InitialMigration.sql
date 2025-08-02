-- Client table
CREATE TABLE IF NOT EXISTS "Client" (
    "Identifier" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "Name" TEXT NOT NULL,
    "Address" TEXT NOT NULL,
    "Status" TEXT NOT NULL
);

-- Resource table
CREATE TABLE IF NOT EXISTS "Resource" (
    "Identifier" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "Name" TEXT NOT NULL,
    "Status" TEXT NOT NULL
);

-- UnitOfMeasurement table
CREATE TABLE IF NOT EXISTS "UnitOfMeasurement" (
    "Identifier" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "Name" TEXT NOT NULL,
    "Status" TEXT NOT NULL
);

-- Balance table
CREATE TABLE IF NOT EXISTS "Balance" (
    "Identifier" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "ResourceIdentifier" UUID NOT NULL REFERENCES "Resource"("Identifier"),
    "UnitOfMeasurementIdentifier" UUID NOT NULL REFERENCES "UnitOfMeasurement"("Identifier"),
    "Quantity" DECIMAL NOT NULL
);

-- IncomingResource table
CREATE TABLE IF NOT EXISTS "IncomingResource" (
    "Identifier" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "ResourceIdentifier" UUID NOT NULL REFERENCES "Resource"("Identifier"),
    "UnitOfMeasurementIdentifier" UUID NOT NULL REFERENCES "UnitOfMeasurement"("Identifier"),
    "Quantity" DECIMAL NOT NULL
);

-- OutgoingResource table
CREATE TABLE IF NOT EXISTS "OutgoingResource" (
    "Identifier" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "ResourceIdentifier" UUID NOT NULL REFERENCES "Resource"("Identifier"),
    "UnitOfMeasurementIdentifier" UUID NOT NULL REFERENCES "UnitOfMeasurement"("Identifier"),
    "Quantity" DECIMAL NOT NULL
);

-- IncomingDocument table
CREATE TABLE IF NOT EXISTS "IncomingDocument" (
    "Identifier" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "Number" TEXT NOT NULL,
    "Date" DATE NOT NULL
);

-- OutgoingDocument table
CREATE TABLE IF NOT EXISTS "OutgoingDocument" (
    "Identifier" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "Number" TEXT NOT NULL,
    "ClientIdentifier" UUID NOT NULL REFERENCES "Client"("Identifier"),
    "Date" DATE NOT NULL,
    "Status" TEXT NOT NULL
);

-- Insert initial migration marker
INSERT INTO "AppliedMigrations" ("MigrationName")
VALUES ('1_InitialMigration')
    ON CONFLICT ("MigrationName") DO NOTHING;