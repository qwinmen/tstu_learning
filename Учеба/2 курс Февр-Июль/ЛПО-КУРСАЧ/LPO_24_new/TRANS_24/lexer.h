#ifndef LEXER_H
#define LEXER_H
#include <QDebug>
#include <QTextStream>
#include <qfile.h>
enum LexemType {
    T_START = 0,
    T_PROG,
    T_VARS,
    T_PROG_BEGIN,
    T_PROG_END,
    T_BEGIN,
    T_END,
    T_WHILE,
    T_DO,
    T_READ,
    T_WRITE,
    T_SET,
    T_O_ABS,
    T_C_ABS,
    T_O_PAR,
    T_C_PAR,
    T_SEMICOLON,
    T_COLON,
    T_COMMA,
    T_DOT,
    T_PLUS,
    T_MINUS,
    T_MUL,
    T_DIV,
    T_GT,
    T_INT,
    T_REAL,
    T_VAR,
    T_CONST,
    T_NAME,
    THE_END,
    NT
};


//Лексема. Описывается типом(переменная, скобка, константа и тд) и значением (нужно только для переменных и констант)
struct Lexem{
    LexemType type;
    QString value;
    int line;
};

//Проверяет, можно ли пропустить этот символ(чтобы пропускать несколько пробелов подряд)
bool isSkipable(QChar c)
{
    return !c.isDigit() && !c.isLetter() && !c.isPunct() && !c.isSymbol();
}

//Проверяет, является ли символ символом-разделителем(тем, что слова друг от друга отделяет)
bool isSeparator(QChar c)
{
    return isSkipable(c) || (QString(":*/+-|{}();.,=").indexOf(c)!=-1);
}



class Lexer {
public:
    Lexer(const QString &string){
        str = string;
        end = str.length();
        lexemTypes["программа"]=T_PROG;
        lexemTypes["переменные"]=T_VARS;
        lexemTypes["начало"]=T_PROG_BEGIN;
        lexemTypes["конец"]=T_PROG_END;
        lexemTypes["{"]=T_BEGIN;
        lexemTypes["}"]=T_END;
        lexemTypes["пока"]=T_WHILE;
        lexemTypes["выполнять"]=T_DO;
        lexemTypes["читать"]=T_READ;
        lexemTypes["вывести"]=T_WRITE;
        lexemTypes["="]=T_SET;
        lexemTypes["|"]=T_O_ABS;
        lexemTypes["("]=T_O_PAR;
        lexemTypes[")"]=T_C_PAR;
        lexemTypes[";"]=T_SEMICOLON;
        lexemTypes[":"]=T_COLON;
        lexemTypes[","]=T_COMMA;
        lexemTypes["."]=T_DOT;
        lexemTypes["+"]=T_PLUS;
        lexemTypes["-"]=T_MINUS;
        lexemTypes["/"]=T_DIV;
        lexemTypes["*"]=T_MUL;
        lexemTypes["целые"]=T_REAL;
        lexemTypes["вещественные"]=T_INT;
        lexemTypes[">"] = T_GT;
    }

    Lexem getNextLexem()
    {
        QString buffer = "";
        Lexem lexem;
        QChar c;
        lexem.line = line;
        //Один символ считываем в любом случае
        if(pos < end){
            c = readChar();
            buffer+=c;
            if(!isSeparator(c)){
                //Считываем посимвольно лексему до разделителя
                while(pos < end){
                  c = readChar();
                  if(isSeparator(c)){
                       unreadChar();
                      break;}
                  buffer+=c;
                }
            }
        } else {
            lexem.type = THE_END;
            return lexem;
        }


        //Пропускаем пробелы и переносы строк
        while(pos < end){
            c = readChar();
            if(!isSkipable(c)){
                unreadChar();
                break;
            }
        }
        lexem.value = buffer;
        lexem.type = getLexemType(buffer);

        return lexem;
    }

private:

    //Считываем один символ из файла
    QChar readChar()
    {

        if(str[pos]=='\n')
            line++;
        return str[pos++];
    }

    void unreadChar()
    {
        /*if(str[pos]=='\n')
            line--;*/
        pos--;
    }

    // Находим тип лексемы
    LexemType getLexemType(const QString &str)
    {
        // Если он есть в массиве типов, то возвращаем его
        if(lexemTypes.contains(str.toLower())){
            return lexemTypes[str];
        } else {
            //если это число, то константа
            if(str[0].isDigit())
                return T_CONST;
            else
                //иначе считаем его переменной
                return T_VAR;
        }
    }

    // Массив типов лексем
    QMap<QString, LexemType> lexemTypes;
    QString str;
    int pos; //= 0;
    int end ;//= 0;
    int line ;//= 0;
};

#endif // LEXER_H
