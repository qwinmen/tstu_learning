(defun c:test ()
;�������
(setq a (getpoint "\n����� ������ �����:"))
(setq b (getpoint "\n����� ������ �����:"))
(command "Line" a b "")
(princ)

)
(princ)