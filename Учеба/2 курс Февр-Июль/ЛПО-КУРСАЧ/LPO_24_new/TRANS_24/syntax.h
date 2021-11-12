#ifndef SYNTAX_H
#define SYNTAX_H
#include <qvector.h>
#include "lexer.h"

//Матрица операторного предшествования
char matrix[THE_END+3][THE_END+3] = {
//   spvbe{} drw=||();:, +-*/
    " <<< < < <<<< < <<<        <  =", //start
    "                =          < = ", //program
    "   >            =<<      <<<   ", // peremennye
    "    =  < <<<<   =<         <   ", //begin
    "                =  =           ", //end
    "      =< <<<<   =<         <   ",   //{
    "                >>             ",   //}
    "        =   < <     <<<<<  <<  ",  //while
    "     < < <<<    ><         <   ",  //do
    "              =                ",  //read
    "              =                ",  //write
    "      >     < < >   <<<<   <<  ",  //=
    "            ==< >   <<<<>  <<  ",  //||
    "               >>   >>>>>      ",  //||
    "            < <=  < <<<<   <<  ",  //(
    "    >   >   >  >>   >>>>>      ",  //)
    "  === =< <<<    =<<      <<<   ", // ;
    "     <     =             >>    ",  // :
    "               > ==        <<  ",  // ,
    "                              >", // .
    "      > >   <><>>   >><<>  <<  ", //plus
    "      > >   <><>>   >><<>  <<  ", //minus
    "      > >   <><>>   >>>>>  <<  ", //mulSS
    "      > >   <><>>   >>>>>  <<  ", //div
    "        >   <><>    <<<<   <<  ", //gt
    "                >              ",
    "                >              ",
    "      > >  >>> >>>> >>>>>      ",
    "        >   >> >>   >>>>>      ",
    "                              ",
    "                              "
};

int find_prev_term(QVector<Lexem> &stack, int pos)
{
    while(pos>0){
        pos--;
        if(stack[pos].type!=NT)
        return pos;
    }
    return -1;
}

// Ищем отношение >
bool is_closing(QVector<Lexem> &stack, int pos)
{
    int ppos = find_prev_term(stack, pos);
    if(ppos == -1)
        return false;
    if(matrix[stack[ppos].type][stack[pos].type] == '>')
        return true;
    return false;
}

// Ищем отношение <
int find_open_term(QVector<Lexem> &stack, int pos)
{
    int tpos = pos, ppos;
    while(true){
        ppos = find_prev_term(stack, tpos);

        if(ppos == -1) return -1;

        if(matrix[stack[ppos].type][stack[tpos].type] == '<')
            return ppos + 1;

        if(matrix[stack[ppos].type][stack[tpos].type] == ' ')
            return -1;
        tpos = ppos;
    }
}

void debug_vector(QVector<Lexem> &v, QTextStream &out)
{
    for(int i = 0; i < v.count(); i++){
        out << v[i].value << " ";
    }
    out << "\n";
}

// роверяем, может ли лексема быть частью выражения
bool is_operand(Lexem l)
{
    return l.type == T_VAR || l.type == T_CONST || l.type == NT;
}

// Проверка, оператор ли это
bool is_operator(Lexem l)
{
    return l.type == T_PLUS || l.type == T_MINUS || l.type == T_MUL || l.type == T_DIV || l.type == T_GT || l.type == T_SET;
}

// Все функции, начинающиеся с match - проверка синтаксиса разных выражений
// Проверка правильности операции
bool match_operation(QVector<Lexem> &chain)
{
    // Проверяем унарный минус
    if (chain.count() == 2 &&
            chain[0].type == T_MINUS &&
            is_operand(chain[1]))
        return true;
    if(chain.count() == 3 &&
            is_operand(chain[0]) &&
        is_operator(chain[1]) &&
        is_operand(chain[2]) ){
        return true;
    } else {
        // Список переменных
        for(int i = 0; i< chain.count(); i+=2){
            if((chain[i].type == T_VAR || chain[i].type == NT)){
                if(i!=0){
                    if(chain[i-1].type != T_COMMA)
                        return false;
                }
            } else {
                return false;
            }
        }
        return true;
    }
    return false;
}

// Проверяем всю программу
bool match_program(QVector<Lexem> &chain)
{
    if(chain[0].type == T_PROG && chain[chain.count()-1].type == T_DOT)
        return true;
    return false;
}

// Проверяем блок кода (между { и } )"
bool match_code_block(QVector<Lexem> &chain)
{
    if(chain[0].type == T_BEGIN && chain[chain.count()-1].type == T_END)
        return true;
    return false;
}

//Правильность цикла
bool match_cycle(QVector<Lexem> &chain)
{
    if(chain[0].type == T_WHILE
            && is_operand(chain[1])
            && chain[2].type == T_DO)
        return true;
    return false;
}

// Модуль
bool match_abs(QVector<Lexem> &chain)
{
    if(chain.count() == 3 &&
            chain[0].type == T_O_ABS &&
            is_operand(chain[1]) &&
            chain[2].type == T_C_ABS)
        return true;
    return false;
}
// Одиночная переменная
bool match_var(QVector<Lexem> &chain)
{
    if(chain.count() == 1 &&
       is_operand(chain[0])) return true;
    return false;
}

//Тип переменной
bool match_vartype(QVector<Lexem> &chain)
{
    if(chain.count() == 2 &&
            is_operand(chain[0]) &&
       (chain[1].type == T_REAL || chain[1].type == T_INT)) return true;
    return false;
}

// Читать или вывести
bool match_function(QVector<Lexem> &chain)
{
    if(chain.count() == 2 &&
       (chain[0].type == T_READ || chain[0].type == T_WRITE ) &&
        is_operand(chain[1]))
            return true;
    return false;
}

// Удаляем все открытые скобки , точки с запятой и двоеточия из дерева (они только мешают при анализе)
// И проверяем синтаксис, чтобы не было, например, переменная=+, а было переменная=переменная+переменная
bool prepare_chain(QVector<Lexem> &chain)
{
    QVector<Lexem> tmp;
    for(int i = 0; i < chain.count(); i++){
        if(chain[i].type != T_O_PAR &&
           chain[i].type != T_C_PAR &&
           chain[i].type != T_SEMICOLON &&
           chain[i].type != T_COLON)
           tmp.push_back(chain[i]);
    }
    if(tmp.count() == 0) return true;
    if(match_var(tmp)) return true;
    if(match_vartype(tmp)) return true;
    if(match_operation(tmp))  return true;
    if(match_abs(tmp)) return true;
    if(match_cycle(tmp)) return true;
    if(match_function(tmp)) return true;
    if(match_code_block(tmp)) return true;
    if(match_program(tmp)) return true;
    return false;
}

// Убираем цепочку лексем из списка
QVector<Lexem> remove_chain(QVector<Lexem> &stack, int start, int end)
{
 QVector<Lexem> chain;
 for(int i = start; i < end; i++){
    chain.push_back(stack[i]);
 }
 stack.remove(start, end-start);
 return chain;
}

// Проверка наличия переменной в списке объявленных
bool has_var(const QVector<Lexem> &vars, Lexem lex)
{
    for(int i = 0; i < vars.count(); i++){
        if(vars[i].value == lex.value)
            return true;
    }
    return false;
}

//Генерация кода
void genCode(QVector<Lexem> &lex, QVector<QVector<Lexem> > &nts, QTextStream &res)
{
    // Чтобы типы переменных норм выводились
    if(match_vartype(lex)){
        switch(lex[1].type){
         case T_REAL:
            res<<"double ";
            break;
          case T_INT:
            res << "int ";
            break;
          default:
            break;
        }
        lex.pop_back();
    }
    // Выводим верный скелет программы
    if(match_program(lex)){
        res << "int main(int argc, char *argv[])\n{\n";
        lex.remove(0,3);
    }

    // Общий случай
    for(int i = 0; i<lex.count(); i++){
        Lexem l = lex[i];
        qDebug() << l.value;
    switch(l.type){
        case NT:
            qDebug() << l.line;
            genCode(nts[l.line], nts, res);
            break;
        case T_PROG:
            break;
        case T_VARS:
        case T_START:
        case T_COLON:
        case T_PROG_BEGIN:
        case T_DOT:
            break;
        case T_O_ABS:
            res << "abs(";
            break;
        case T_C_ABS:
        case T_DO:
            res << ") ";
            break;
        case T_WHILE:
            res << "while(";
            break;
        case T_SEMICOLON:
            res << ";\n";
            break;
        case T_READ:
            res << "read";
            break;
        case T_WRITE:
            res << "write";
            break;
        case T_PROG_END:
            res << ";\n}";
            break;
        case T_BEGIN:
            res << "{\n";
            break;
        case T_END:
            res << ";\n}";
            break;
        default:
            res << l.value;
            break;
    }
    }
}

// Компиляция
int compile(const QString &path, QString *str, QString *res)
{
    QTextStream out(str);
    QTextStream result(res);
    Lexer *lexer = new Lexer(path);
    Lexem lex;
    QVector<QVector<Lexem> > nts; //Вектор нетерминальных символов

    QVector<Lexem> vars; // Список переменных
    QVector<Lexem> ints;
    QVector<Lexem> reals;
    LexemType v_type = T_INT;
    int line = 0;
    int abs_counter = 0;
    int pos = 0, ppos = 0;
    bool var_section = false, prog_section = false;
    Lexem prog_name;

    QVector<Lexem> stack;
    QVector<Lexem> chain;

    lex.type = T_START;
    stack.push_back(lex);

    // Здесь реализована двухпроходность - читаем по одной лексеме и проводим анализ
    while(lex.type != THE_END){
        // Читаем лексему
        lex = lexer->getNextLexem();
        if(lex.type == T_O_ABS){
            abs_counter++;
            if(abs_counter % 2 == 0)
                lex.type = T_C_ABS;
        }

        //if(lex.type == T_INT || lex.type == T_REAL)

        stack.push_back(lex);
        pos++;
        line = lex.line;
        if(lex.type == T_PROG)
            prog_section = true;
        if(lex.type == T_VARS){
            var_section = true;
            prog_section = false;
        }

        if(lex.type == T_PROG_BEGIN)
            var_section = false;

        // Если это переменная. заносим её в список переменных
        if(lex.type == T_VAR && var_section)
            vars.push_back(lex);

        // Проверка  - была ли переменная объявлена
        if(lex.type == T_VAR && !var_section){
            if(!prog_section) {
                if(!has_var(vars, lex) || lex.value == prog_name.value){
                    out << "Error: unknown variable in line " << line << "\n";
                    return -1;
                }
            } else {
                prog_name = lex;
            }
        }
        // Проводим синт. анализ
        while(true){
            debug_vector(stack, out);

            if(!is_closing(stack, pos)) break;
            ppos = find_open_term(stack, pos);

            if(ppos < 0) {
                out << "Syntax error in line " << line << "\n";
                return -1;
            }
            // Удаляем цепочку лексем
            chain = remove_chain(stack, ppos, pos);
            if(!prepare_chain(chain)){
                out << "Syntax error in line " << line << "\n";
                return -1;
            }
            nts.push_back(chain);
            // Заменяем на обозначение нетерминального символа
            Lexem tlex;
            tlex.type = NT;
            tlex.line=nts.count() - 1 ;
            tlex.value=QString("<N%1>").arg(nts.count() - 1);
            stack.insert(ppos, tlex);
            pos = stack.count()-1;
        }
    }

    debug_vector(stack, out);
    // Финальная проверка, что от тела программы остаётся один нетерминальный символ
    if(stack.count() == 3 &&
            stack[0].type == T_START &&
            stack[1].type == NT &&
            stack[2].type == THE_END){
// Генерация кода
        genCode(stack, nts, result);
        return 1;
    } else {
        out << "Syntax error in line " << line << "\n";
        return -1;
    }
    return 1;
}

#endif // SYNTAX_H
