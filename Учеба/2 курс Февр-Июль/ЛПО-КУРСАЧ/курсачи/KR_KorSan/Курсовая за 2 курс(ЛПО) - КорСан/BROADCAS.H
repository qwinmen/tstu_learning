class CBroadcast {
private:
       FILE *lrez,*brez,*IDN;
       char a[10][20],masIDN[40][10],string[10];
       int lex,k,lexold1,lexold2,num_cycle,lexold3,num_skobki;
       int masType[40],introdbuff[10],num_a[10];
public:
    void Bgeneral();
    void Bread_dat();
    void Bbegin_program();
    void Blist_oper();
    void Barith_expr();
    void BCycleArith_expr();
    void Blist_IDN();
    void Bdeclare();
    void Bintroduce();
    void Bconclusion();
    void Bcondition();
    void Bappropriate();
    void BCycleAppropriate();
    void Bcycle();
    void Bnext_lex();
};