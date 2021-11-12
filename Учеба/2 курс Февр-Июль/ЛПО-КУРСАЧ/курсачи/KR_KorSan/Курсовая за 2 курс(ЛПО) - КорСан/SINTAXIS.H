class CSintaxis {
private:
	int lexold3,lexold2,lexold1,lex;
	int num_skobki,num_stroki,num_cycle,cstrok,FlagBegin;
	char *stek_arith_oper,*stek_TS;
	FILE *lrez,*mistake;
public:
    void list_oper();
    void arith_expr();
    void list_IDN();
    void begin_program();
    void declare();
    void introduce();
    void conclusion();
    void condition();
    void appropriate();
    void cycle();
    void next_lex();
    void sin_analiz();
};