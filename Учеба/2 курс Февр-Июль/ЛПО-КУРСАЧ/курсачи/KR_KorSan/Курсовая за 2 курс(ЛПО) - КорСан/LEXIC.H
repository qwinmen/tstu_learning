class CLexic {
private:
	FILE *out,*listIDN,*mistake;
	char masNTS[40][10],masIDN[20][10];
	char stpoka[10];
	char nameif[10];
	char a[20];
	int countNTS,i,q,w,cstrok,heshidn;
	int FlagDeclare,FlagTypeIDN,FlagIDN,FlagOutL,FlagBukvaCifra;
	int FlagBeginCifra,FlagCifra,FlagBukva,flag5,FlagLex,FlagEndLine;
public:
    void read_if();
    void begin();
    void end();
    int hesh();
    void analiz();
    void readdat();
    void findlex();
    void Lmistake();
    void view_if();
    void view_of();
};