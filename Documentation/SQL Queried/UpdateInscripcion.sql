BEGIN
    UPDATE inscripcion
    SET
        Descripcion=p_Descripcion,
        Id_Materia=p_Id_Materia,
        Id_Estudiante=p_Id_Estudiante
    WHERE Id_Inscripcion = p_Id;
END