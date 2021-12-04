(defun c:test ()
;коменты
(setq a (getpoint "\n¬води первую точку:"))
(setq b (getpoint "\n¬води вторую точку:"))
(command "Line" a b "")
(princ)

)
(princ)