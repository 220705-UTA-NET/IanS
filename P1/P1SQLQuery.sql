-- DROP TABLE PROJ1.MONSTER;
-- DROP TABLE PROJ1.CHARACTER;

-- INSERT INTO PROJ1.Monster (mon_name, mon_health)
-- VALUES
-- ('Boar', 15);

SELECT * FROM PROJ1.Monster;

-- SELECT mon_id, mon_name, mon_health
-- FROM PROJ1.Monster
-- WHERE mon_id = 1;

-- UPDATE PROJ1.Monster
-- SET
--     mon_name = 'Spider',
--     mon_health = 5
-- WHERE mon_id = 1;

-- DELETE
-- FROM PROJ1.Monster
-- WHERE mon_id = 9;

-- DECLARE @max int
-- SELECT @max=MAX([mon_id])
-- FROM PROJ1.Monster
-- IF @max IS NULL
--     SET @max = 0
-- DBCC CHECKIDENT ('PROJ1.Monster', RESEED, @max);

SELECT char_id, char_name, char_health, char_killcount
FROM PROJ1.Character;