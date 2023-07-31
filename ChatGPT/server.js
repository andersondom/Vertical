const express = require('express');
const axios = require('axios');

const app = express();
const port = 3000;

app.use(express.static('public'));
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

app.get('/', (req, res) => {
    res.sendFile(__dirname + '/public/index.html');
});

app.post('/processar-cadastro', async (req, res) => {
    // Obter dados do formulário
    const nome = req.body.nome;
    const email = req.body.email;
    const telefone = req.body.telefone;
    const instrumento = req.body.instrumento;
    const experiencia = req.body.experiencia;

    // Enviar dados para o ChatGPT
    const respostaChatGPT = await enviarMensagemChatGPT(
        `Nome: ${nome}\nEmail: ${email}\nTelefone: ${telefone}\nInstrumento: ${instrumento}\nExperiência: ${experiencia}`
    );

    // Realizar ações com a resposta do ChatGPT, como armazenar em um banco de dados ou enviar por e-mail

    // Retornar resposta para o cliente
    res.send('Cadastro recebido com sucesso!');
});

async function enviarMensagemChatGPT(mensagem) {
    const url = 'https://api.openai.com/v1/chat/completions';

    const response = await axios.post(url, {
        messages: [{ role: 'system', content: 'Você é um instrumentista?' }, { role: 'user', content: mensagem }],
    }, {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer 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',
        },
    });

    return response.data.choices[0].message.content;
}

app.listen(port, () => {
    console.log(`Servidor rodando em http://localhost:${port}`);
});