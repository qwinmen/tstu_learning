(defun c:proge ()
(setq L1 (getreal "¬веди размер L1:") )
(setq L2 (getreal "¬веди размер L2:") )
(setq D1 (getreal "¬веди размер D1:") )
(setq D2 (getreal "¬веди размер D2:") )
(setq L3 (getreal "¬веди рассто€ние между видами:") )

(setq p1 (list 0 (/ (- d2) 2) ) )
(setq p2 (list L1 (/ (- d2) 2) ) )
(setq p3 (list L1 (/ (- d1) 2 ) ) )

(setq p4 (list (+ L1 L2) (/ (- d1 ) 2 ) ) )
(setq p5 (list (+ L1 L2) (/ d1 2 ) ) )
(setq p6 (list L1 (/ d1 2 ) ) )

(setq p7 (list L1 (/ d2 2 ) ) )
(setq p8 (list 0 (/ d2 2 ) ) )
(setq p9 (list (+ L1 L2 L3 (/ D1 2)) 0 ) )

(command "line" p1 p2 p3 p4 p5 p6 p7 p8 "c")
(command "line" p2 p7 "")

(command "circle" p9 d1 )
(command "circle" p9 d2 )

(princ)
)
(princ)