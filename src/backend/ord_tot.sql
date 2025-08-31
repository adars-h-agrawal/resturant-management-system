CREATE OR REPLACE FUNCTION get_order_total(p_order_id IN NUMBER)
RETURN NUMBER
IS
  v_total NUMBER := 0;
BEGIN
  SELECT SUM(total_price)
  INTO v_total
  FROM order_items
  WHERE order_id = p_order_id;

  RETURN NVL(v_total, 0);
END;
/
