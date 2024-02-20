.code

; a -> rsi
; b -> rdi
; r -> r8
; n -> r9

AsmAdd proc
    push rbp
    mov rbp, rsp
   
    mov rsi, rdx    
    mov rdi, rcx  
    mov rax, r8
    mov rbx, r9

    xor r10d, r10d ; <- i = 0

 AsmAdd_loop:
    movups xmm0, [rsi + r10d * 4]
    movups xmm1, [rdi + r10d * 4]
    addps xmm0, xmm1
    movups [rax + r10d * 4], xmm0
    inc r10d
    cmp r10d, rbx
    jl AsmAdd_loop

    pop rbp
    ret
AsmAdd endp

AsmAddQuatro proc
    push rbp
    mov rbp, rsp
   
    mov rsi, rdx    
    mov rdi, rcx    

    movups xmm0, [rsi]
    movups xmm1, [rdi]
    addps xmm0, xmm1

    mov rax, r8
    movups [rax], xmm0  

    pop rbp
    ret
AsmAddQuatro endp

end
