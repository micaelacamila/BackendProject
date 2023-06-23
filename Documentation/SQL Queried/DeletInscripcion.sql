DELIMITER //

CREATE PROCEDURE EliminarInscripcion(
	IN p_Id INT
)
BEGIN
    DELETE FROM Inscripcion WHERE Id_Inscripcion = p_Id;
END//

DELIMITER ;
