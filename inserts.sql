INSERT INTO [dbo].[UserType] VALUES
('AdminUser'), 
('RegularUser'), 
('ProfesionalUser')

INSERT INTO [dbo].[User] VALUES
('Santiago Martinez', 'smartinez9626@gmail.com', 1)

INSERT INTO [dbo].[HabitType] VALUES
('Fisco'),
('Alimentacion'),
('Psicologico')

INSERT INTO [dbo].[Habit] VALUES
('Realizar 30 minutos de ejercicio cardiovascular cada d�a', 1, 'Ejercicio Diario'),
('Incluir al menos cinco porciones de frutas y verduras en la dieta diaria', 2, 'Dieta Saludable'),
('Dedicar 15 minutos al d�a a la meditaci�n para mejorar la claridad mental y reducir el estr�s', 3, 'Meditaci�n Diaria')


INSERT INTO [dbo].[Unit] VALUES
('GR'),
('ML')

INSERT INTO [dbo].[ViaAdmin] VALUES
('Oral'),
('Intravenosa'),
('Anal'),
('Ocular')

INSERT INTO [dbo].[Medication] VALUES
('Acetaminofen', 1, 1, 500),
('Fregen Gotas', 2, 4, 2500),
('Diclofenalco', 2, 2, 500)