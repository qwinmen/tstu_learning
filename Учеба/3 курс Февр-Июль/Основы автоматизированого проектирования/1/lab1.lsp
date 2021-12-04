(defun c:lab1 ()

(setq NN (getpoint "\nНачало координат: ")) ;[00]
(setq L1 (getreal "L1 ширина35:") )
(setq L2 (getreal "L2 высота30:") )
(setq L3 (getreal "L3 высота_порог10:") )
(setq L4 (getreal "L4 длина40:") )
(setq L5 (getreal "L5 длина_порог15:") )
(setq D1 (getreal "D1 диаметр15:") )
;Вид спереди
(setq tmp (nth 1 NN))
(setq tmpX (car NN))
(setq tmpY (cdr NN))

(setq p1 (list tmpX tmp))
(setq p2 (list tmpX (+ tmp (- L2 L3))))
(setq p3 (list (+ tmpX L1) (nth 1 p2)))
(setq p4 (list (nth 0 p3) (nth 1 p1)))
(setq p5 (list (nth 0 p3) (- tmp L3)))
(setq p6 (list tmpX (- tmp L3)))

;Вид сбоку
(setq p7 (list (+ (nth 0 p5) L1) (nth 1 p5)))
(setq p8 (list (+ (nth 0 p5) L1) (nth 1 p1)))
(setq p9 (list (+ (nth 0 p8) L5) (nth 1 p4)))
(setq p10 (list (nth 0 p9) (nth 1 p3)))
(setq p11 (list (+ (nth 0 p8) L4) (nth 1 p3)))
(setq p12 (list (+ (nth 0 p8) L4) (nth 1 p7)))

;Вид сверху
(setq p13 (list tmpX (- (nth 1 p6) L1)))
(setq p14 (list (+ (nth 0 p13) L1) (nth 1 p13)))
(setq p15 (list (nth 0 p14) (- (nth 1 p14) (- L4 L5))))
(setq p16 (list (nth 0 p14) (- (nth 1 p15) L5)))
(setq p17 (list tmpX (nth 1 p16)))
(setq p18 (list tmpX (nth 1 p15)))
(setq p19 (list (+ (/ L1 2) (nth 0 p13)) (+ (/ (- L5 L4) 2) (nth 1 p13)) ))

;----вертикальный пунктир---
;(load "lab1")
(setq pn (list (nth 0 p19) (+ (nth 1 p2) L3))) ;начало пунктира
(setq stp 5) ;начало+шаг = конец_отрезка
(setq pe (list (nth 0 p19) (- (nth 1 pn) stp))) ;конец_отрезка
(setq index 0)

	(while (< index 25) 				
		(if (= (rem index 2) 1) 
			(command "line" pn pe "") 			  			
		)		
		(setq pn (list (nth 0 p19) (nth 1 pe)))
		(setq pe (list (nth 0 p19) (- (nth 1 pn) stp) ))
			  
		;(princ "НАЧАЛО----->")
		;(princ pn)
		;(princ "Конец----->")
		;(princ pe)
		
		(setq index (+ 1 index)) ;index++
	)
;-------



;Вид спереди
(command "line" p1 p2 p3 p4 p5 p6 "c")
(command "line" p1 p4 "")
(setq pn (list (- (nth 0 p6) 10) (+ (/ L2 2) (nth 1 p6))))
(command "dimlinear" p6 p2 "v" pn "")

;пунктир l f
;; ставим тип линии в соответствии со слоем
(command "_.linetype" "_s" "bylayer" "")
;; ставим тип линии штрих
(command "_.linetype" "_s" "jis_02_1.2" "")
(setq llbl (list (+ (/ (- L1 D1) 2) (nth 0 p2)) (nth 1 p2)));старт
(setq flbl (list (nth 0 llbl) (nth 1 p6)));финиш
(command "line" llbl flbl "")
(setq llbl (list (+ (nth 0 flbl) D1) (nth 1 p2)));старт
(setq flbl (list (nth 0 llbl) (nth 1 p6)));финиш
(command "line" llbl flbl "")
(command "_.linetype" "_s" "bylayer" "")
(command "_.linetype" "_s" "line" "")

;Вид сбоку
(command "line" p7 p8 p9 p10 p11 p12 "c")
(setq pn (list (+ (nth 0 p7) (/ L4 2)) (- (nth 1 p12) 10)))
(command "dimlinear" p7 p12 pn )
(setq pn (list (+ (nth 0 p8) (/ L5 2)) (+ (nth 1 p8) 10)))
(command "dimlinear" p8 p9 pn )
;пунктир l f
(command "_.linetype" "_s" "bylayer" "")
(command "_.linetype" "_s" "jis_02_1.2" "")
(setq ttmp (/ (- (- (nth 0 p11) (nth 0 p10)) D1) 2))
(setq llbl (list (+ ttmp (nth 0 p10)) (nth 1 p2)));старт
(setq flbl (list (nth 0 llbl) (nth 1 p6)));финиш
(command "line" llbl flbl "")
(setq llbl (list (+ (nth 0 flbl) D1) (nth 1 p2)));старт
(setq flbl (list (nth 0 llbl) (nth 1 p6)));финиш
(command "line" llbl flbl "")
(command "_.linetype" "_s" "bylayer" "")
(command "_.linetype" "_s" "line" "")

;Вид сверху
(command "line" p13 p14 p15 p16 p17 "c")
(command "line" p18 p15 "")
(command "circle" p19 "d" D1 )
(command "dimlinear" p16 p17 pe)
(setq rad (list (+ (nth 0 p15) 10) (nth 1 p19)))
(setq D1 (list (+ (nth 0 p19) (/ D1 2)) (nth 1 p19)))
(command "dimradius" D1 rad)
;(command "dimdiameter" p19 D1)

(command "_zoom" "e" "")
;(command "_zoom" "all" "")

(princ)
)
(princ)