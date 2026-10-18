# AiQwen25vlApi

## O que e este projeto

Este projeto demonstra uma API .NET preparada para processar imagens com o modelo Qwen2.5-VL via Ollama.

## Funcionalidade

A API possui rotas de inserir, alterar, excluir e pesquisar usuarios em memoria. Tambem possui a rota `POST /api/UsuariosQwenVision/{id}/processar-imagem`, que recebe um prompt e uma imagem por `multipart/form-data`, usa os dados do usuario como contexto e retorna o resultado do processamento.

## Objetivo

O objetivo e mostrar como combinar dados de usuario, prompt personalizado e imagem para exemplos de IA multimodal usando Qwen2.5-VL. O exemplo funciona com resposta simulada e pode ser configurado para usar Ollama real.

## Onde pode ser usado

Pode ser usado em analise de documentos, leitura de imagens, suporte visual, classificacao de anexos, validacao de comprovantes e APIs que se conectam a um servidor Ollama com modelo de visao.
