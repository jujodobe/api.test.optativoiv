-- public.persona definition

-- Drop table

-- DROP TABLE public.persona;

CREATE TABLE public.persona (
	id serial4 NOT NULL,
	nombre varchar(30) NOT NULL,
	apellido varchar(30) NOT NULL,
	edad int4 NULL,
	email varchar(60) NULL,
	telefono varchar(15) NOT NULL,
	CONSTRAINT persona_pk PRIMARY KEY (id)
);
CREATE UNIQUE INDEX persona_id_idx ON public.persona USING btree (id);