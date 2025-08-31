CREATE OR REPLACE TRIGGER log_menu_edit
BEFORE UPDATE ON menu
FOR EACH ROW
DECLARE
    v_staff_id VARCHAR2(20);
BEGIN
    BEGIN
        SELECT staff_id INTO v_staff_id FROM current_editor WHERE ROWNUM = 1;

        INSERT INTO edits (staff_id, item_no, edit_time)
        VALUES (v_staff_id, :OLD.item_no, CURRENT_TIMESTAMP);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            NULL;
    END;
END;
/
