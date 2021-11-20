unit Unit_Princ;

interface

uses
  Windows, Controls, Forms, Graphics, Classes, ExtCtrls,
  GraphUtil; // Juste pour GetShadowColor... Une fantaisie! :p

type
  TFichePrinc = class(TForm)
    Img_Surface: TImage;
    procedure Redessiner;
    procedure FormCreate(Sender: TObject);
    procedure Img_SurfaceMouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure Img_SurfaceMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Img_SurfaceMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
  private
    { Déclarations privées }
  public
    { Déclarations publiques }
  end;

var
  FichePrinc: TFichePrinc;


implementation


{$R *.dfm}


const
      NbreLignes = 20; // Ou plus... Mais c'est vite le bordel.
      Ecart      = 5 ; // Tolérance d'écart pour sélectionner la ligne.

type
      TSelectionDansLigne = (Rien, LePoint1, LePoint2, LaLigne);

      TLigne = Record
             PtA : TPoint;
             PtB : TPoint;
      end;

var
      Ligne        : ARRAY[1..NbreLignes] of TLigne;
      Selection    : TSelectionDansLigne;
      LigneEnCours : Integer;
      Pt1, Pt2     : TPoint; // Les 2 extrémités de la ligne sélectionnée.
      PtDrag       : TPoint; // Points du drag lors du mousemove.


                                                                                {
********************************************************************************
*******************   QUELQUES FONCTIONS ET PROCEDURES    **********************
********************************************************************************
                                                                                }

procedure TFichePrinc.Redessiner;
  {Redessine toutes les lignes.}
  var
      i          : Integer;
  begin
  with Img_Surface.Canvas do begin
    {Dessin du fond.}
    Brush.Color := clSkyBlue;
    FillRect(ClipRect);
    {Dessin de l'ombre de la ligne sélectionnée, si elle existe.}
    if Selection in [LePoint1, LePoint2, LaLigne] then begin
      Pen.Color   := GetShadowColor(clSkyBlue); // GraphUtil Unit pour GetShadowColor, à partir de D6.
      Brush.Color := Pen.Color;
      Pen.Width   := 2;
      MoveTo(Pt1.X+2, Pt1.Y+2);
      LineTo(Pt2.X+2, Pt2.Y+2);
      {O--------íèæíèé-ñëîé----------O}
      Ellipse(Pt1.X-Ecart+2,Pt1.Y-Ecart+2,Pt1.X+Ecart+2,Pt1.Y+Ecart+2);
      Ellipse(Pt2.X-Ecart+2,Pt2.Y-Ecart+2,Pt2.X+Ecart+2,Pt2.Y+Ecart+2);
    end;
    {Dessin des lignes, 1 pixel de large.}
    Pen.Color := clNavy;
    Pen.Width := 1;
    for i := 1 to NbreLignes do begin
      MoveTo(Ligne[i].PtA.X, Ligne[i].PtA.Y);
      LineTo(Ligne[i].PtB.X, Ligne[i].PtB.Y);
    end;
    {Si il y a une ligne sélectionnée, dessin de cette ligne.}
    if Selection in [LePoint1, LePoint2, LaLigne] then begin
      {La ligne sélectionnée, 1 pixel de large, rouge.}
      Pen.Color := clRed;
      MoveTo(Pt1.X, Pt1.Y);
      LineTo(Pt2.X, Pt2.Y);
      {*---------âåðõíèé-ñëîé----------*}
      Brush.Color := clLime;    //Couleur intérieure.
      Pen.Color   := clNavy;    //Couleur des bords.
      Ellipse(Pt1.X-Ecart,Pt1.Y-Ecart,Pt1.X+Ecart,Pt1.Y+Ecart);//Î----
      Ellipse(Pt2.X-Ecart,Pt2.Y-Ecart,Pt2.X+Ecart,Pt2.Y+Ecart);//----Î
    end;
  end;//with
end;

////////////////////////////////////////////////////////////////////////////////

function Distance(Pt1, Pt2:  TPoint): Integer;
  {Calcule la distance Pt1-Pt2 en pixels.}
  begin
  result := Round(Sqrt( Sqr(Pt2.X - Pt1.X) + Sqr(Pt2.Y - Pt1.Y) ));
end;

////////////////////////////////////////////////////////////////////////////////

function ToucheLigne(Pt, Pt1, Pt2:  TPoint):  Boolean;
  {Détermne si Pt est proche du segment Pt1-Pt2 (fonction de Ecart).}
  var
        A,B,Dist : Double;
  begin
  result := false;
  {Calcul des coefficients de la droite Pt1-Pt2 d'équation y = Ax+B}
  if (Pt1.X - Pt2.X) = 0
  then A:=0
  else A := (Pt1.Y - Pt2.Y) / (Pt1.X - Pt2.X);
  B :=  Pt1.Y - A * Pt1.X;
  {Calcul de la distance de Pt à la droite Pt1-Pt2}
  Dist := Abs(Pt.Y - A * Pt.X - B) / Sqrt(1 + Sqr(A));
  {Vérification}
  if (Dist <= Ecart)
  and (Distance(Pt,Pt1) + Distance(Pt,Pt2) <= Dist + Distance(Pt1,Pt2))
  then result := true;
end;

                                                                                {
********************************************************************************
********************************   LE CODE   ***********************************
********************************************************************************
                                                                                }

procedure TFichePrinc.FormCreate(Sender: TObject);
  {On dessine le décor.}
  var
      i : Integer;
  begin
  {On Remplit le tableau de lignes..}
  for i := 1 to NbreLignes do begin
    Ligne[i].PtA := Point(4+Random(Img_Surface.Width -8),
                          4+Random(Img_Surface.Height-8));
    Ligne[i].PtB := Point(4+Random(Img_Surface.Width -8),
                          4+Random(Img_Surface.Height-8));
  end;
  {.. et on trace ces lignes.}
  Redessiner;
end;

////////////////////////////////////////////////////////////////////////////////

procedure TFichePrinc.Img_SurfaceMouseMove(Sender: TObject;
  Shift: TShiftState; X, Y: Integer);
  var
      Delta        : TPoint; // Valeur d'une translation.
      i            : Integer;
  begin
  if Selection = Rien then begin     // Si le bouton n'est pas enfoncé.
      {Simple gestion du curseur.}
      for i := 1 to NbreLignes do begin
          Pt1 := Ligne[i].PtA;
          Pt2 := Ligne[i].PtB;
          if   (Distance(Pt1, Point(X,Y)) < Ecart) //Si le curseur se trouve dans..
            or (Distance(Pt2, Point(X,Y)) < Ecart) //..une des poignées..
            or ToucheLigne(Point(X,Y), Pt1, Pt2)   //..ou près de la ligne,
          then begin
             Screen.Cursor := crHandPoint;         //..on change le curseur.
             break; end
          else Screen.Cursor := crDefault end;
      end//for
      {Gestion des déplacements.}
  else begin                          // Si qq chose est sélectionnné..
      case Selection of
        LePoint1:  Pt1 := Point(X, Y);// on déplace l'extrémité de la ligne..
        LePoint2:  Pt2 := Point(X, Y);
        LaLigne :  begin              // ..ou on 'translate' la ligne.
                    Delta := Point(X-PtDrag.X ,Y-PtDrag.Y);
                    PtDrag := Point(X,Y);
                    Pt1 := Point(Pt1.X + Delta.X, Pt1.Y + Delta.Y);
                    Pt2 := Point(Pt2.X + Delta.X, Pt2.Y + Delta.Y);
                  end;
      end;
      Ligne[LigneEnCours].PtA := Pt1;
      Ligne[LigneEnCours].PtB := Pt2;
      {On redessine le TImage.}
      Redessiner;
  end;
end;

////////////////////////////////////////////////////////////////////////////////

procedure TFichePrinc.Img_SurfaceMouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
 i : Integer;
begin
  Selection := Rien;
  PtDrag    := Point(X,Y);
  // D'abord les extrémités!
  for i := 1 to NbreLignes do
   begin
    Pt1 := Ligne[i].PtA;
    Pt2 := Ligne[i].PtB;
    if      Distance(Pt1, PtDrag) < Ecart then Selection := LePoint1
    else if Distance(Pt2, PtDrag) < Ecart then Selection := LePoint2;
    if Selection in [LePoint1, LePoint2]
    then
     begin
      LigneEnCours := i;
      Pt1 := Ligne[i].PtA;
      Pt2 := Ligne[i].PtB;
      Screen.Cursor := crSizeAll;
      break;
    end;
  end;
  // Puis, si pas d'extémité sélectionnée, on s'occupe de la ligne
  if Selection = Rien then
  for i := 1 to NbreLignes do begin
    if ToucheLigne(PtDrag, Ligne[i].PtA, Ligne[i].PtB)
    then
     begin
      Selection := LaLigne;
      LigneEnCours := i;
      pt1 := Ligne[i].PtA;
      pt2 := Ligne[i].PtB;
      Screen.Cursor := crDrag;
      break;
    end;
  end;
 Redessiner;
end;

////////////////////////////////////////////////////////////////////////////////

procedure TFichePrinc.Img_SurfaceMouseUp(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
begin
 Screen.Cursor := crDefault;
 Selection := Rien;
end;

end.
