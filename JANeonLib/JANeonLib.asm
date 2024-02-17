.code

; a -> rsi
; b -> rdi
; r -> r8
; n -> r9

AsmAdd proc
    push rbp
    mov rbp, rsp

    mov rax, rsi
    movaps xmm0, [rax]  

    mov rax, rdi 
    movaps xmm1, [rax] 

    addps xmm0, xmm1 

    mov rax, r8
    movaps [rax], xmm0    

    pop rbp
    ret
AsmAdd endp

end
