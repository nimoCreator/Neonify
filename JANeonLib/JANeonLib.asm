.code

AsmMixPxComp proc

    ; Load px, neon, and mask into registers
    mov eax, dword ptr [rcx]   ; Wczytaj pierwszy parametr (px) z RCX
    mov ebx, dword ptr [rdx]   ; Wczytaj drugi parametr (neon) z RDX
    mov ecx, dword ptr [r8]    ; Wczytaj trzeci parametr (mask) z R8

    ; Calculate px.R * (255 - mask.R) / 255
    movzx edx, byte ptr [ecx]  ; Wczytaj mask.R do EDX (zero-extended do 32 bitow)
    movzx esi, byte ptr [eax]  ; Wczytaj px.R do ESI (zero-extended do 32 bitow)
    movzx edi, byte ptr [ebx]  ; Wczytaj neon.R do EDI (zero-extended do 32 bitow)
    sub edx, 255                ; Odejmij od 255 mask.R
    imul esi, edx               ; px.R * (255 - mask.R)
    shr esi, 8                  ; px.R * (255 - mask.R) / 255

    ; Calculate neon.R * (mask.R) / 255
    movzx edx, byte ptr [ecx]  ; Ponownie wczytaj mask.R do EDX (zero-extended do 32 bitow)
    imul edi, edx               ; neon.R * mask.R
    shr edi, 8                  ; neon.R * mask.R / 255

    ; Add the two results
    add esi, edi                ; px.R * (255 - mask.R) / 255 + neon.R * (mask.R) / 255

    ; Clamp the result to [0, 255]
    test esi, esi               ; Sprawdz, czy wynik jest ujemny
    jns positive                ; Jesli dodatni, pomin ograniczenie
    xor esi, esi                ; Ustaw wynik na 0, jesli jest ujemny
    jmp finish

positive:
    cmp esi, 255                ; Sprawdz, czy wynik jest wiekszy niz 255
    jle finish                  ; Jesli mniejszy lub rowny 255, pomin ograniczenie
    mov esi, 255                ; Ustaw wynik na 255, jesli jest wiekszy niz 255

finish:
    mov eax, esi                ; Zwroc wynik w rejestrze EAX

    ret

AsmMixPxComp endp












AsmMixPx proc

    movdqu  xmm1, [edi]   ; rgb 
    movdqu  xmm2, [esi]   ; neon
    movdqu  xmm3, [edx]   ; mask 

    cvtdq2ps xmm1, xmm1   ; floaty
    cvtdq2ps xmm2, xmm2  
    cvtdq2ps xmm3, xmm3   

    mulps   xmm1, xmm3    ; px * mask
    mulps   xmm2, xmm3    ; neon * mask
    subps   xmm1, xmm2    ; px * mask - neon * mask
    addps   xmm1, xmm2    ; neon * mask + px * (1 - mask)
    maxps   xmm1, xmm4    ; Clamp result to [0, 1]
    minps   xmm1, xmm5    ; Clamp result to [0, 1]

    cvtps2dq xmm1, xmm1   ; int
    packuswb xmm1, xmm1   ; Pack results into bytes

    ret

AsmMixPx endp

end
