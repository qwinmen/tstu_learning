procedure BinaryInsertionSort(var Arr : array of Real; N : Integer);
var
    B,C,E,I,J,K   :   Integer;
    Tmp :   Real;
begin
    i:=2;
    repeat
        b:=1;
        e:=i-1;
        c:=((b+e) div 2);
        while b<>c do
        begin
            if Arr[c-1]>Arr[i-1] then e:=c
            else b:=c;
            c:=((b+e) div 2);
        end;
        if Arr[b-1]<Arr[i-1] then
        begin
            if Arr[i-1]>Arr[e-1]
               then b:=e+1
               else b:=e;
        end;
        k:=i;
        Tmp:=Arr[i-1];
        while k>b do
        begin
            Arr[k-1]:=Arr[k-1-1];
            dec(k)
        end;
        Arr[b-1]:=Tmp;
        inc(i);
    until not(i<=n);
end;