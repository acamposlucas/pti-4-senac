import React, { useContext, useEffect, useState } from 'react';
import UserContext from '../../contexts/UserContext';
import Card from 'react-bootstrap/Card';

// Define a interface para os dados da família
interface Membro {
  id: number;
  familiaId: number;
  nome: string;
  dataNascimento: string;
  carteiraVacinacaoId: number;
}

interface Familia {
  familiaId: number;
  usuarioId: number;
  membros: Membro[];
}

export function Home() {
  const { setUser } = useContext(UserContext);
  const [familia, setFamilia] = useState<Familia | null>(null); 

  useEffect(() => {

    fetch('https://localhost:7168/api/Familia/{id}') 
      .then(response => response.json())
      .then(data => {
        setUser(data); 
        setFamilia(data); 
      })
      .catch(error => {
        console.error('Erro ao buscar dados:', error);
      });
  }, [setUser]);

  if (!familia) {
    return <div>Carregando...</div>; 
  }

  return (
    <div>
      <h1>Bem-vindo!</h1>
      <h2>Família ID: {familia.familiaId}</h2> 
      <MembrosCadas membros={familia.membros} /> 
    </div>
  );
}

function MembrosCadas({ membros }: { membros: Membro[] }) { 
  return (
    <>
      {membros.length > 0 ? (
        membros.map(membro => (
          <Card
            bg="primary"
            key={membro.id}
            text="white"
            style={{ width: '18rem' }}
            className="mb-2"
          >
            <Card.Header>{`Membro ID: ${membro.id}`}</Card.Header>
            <Card.Body>
              <Card.Title>{membro.nome}</Card.Title>
              <Card.Text>
                Data de Nascimento: {new Date(membro.dataNascimento).toLocaleDateString()} {/* Formatar data */}
              </Card.Text>
              <Card.Text>
                Carteira de Vacinação ID: {membro.carteiraVacinacaoId}
              </Card.Text>
            </Card.Body>
          </Card>
        ))
      ) : (
        <p>Não há membros cadastrados.</p>
      )}
    </>
  );
}

export default Home;
