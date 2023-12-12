import { useNavigate } from "react-router-dom";
import { 
    Card, 
    Image, 
    Group, 
    Badge, 
    Button, 
    Text, 
    Title 
} from '@mantine/core';


function GameCard(props) {
    let navigate = useNavigate(); 
    
    const routeChange = () =>{ 
        let gameName = props.name.replace(' ', '-')
                                 .toLowerCase();

        let path = `/playground/${ gameName }`; 
        navigate(path);
    }

    return(
        <Card shadow="sm" padding="lg" radius="md" withBorder>
            <Card.Section>
                <Image src={props.heroImage} pb={16} />
            </Card.Section>

            <Group justify='space-between'>
                <Title order={3}>
                    {props.name}
                </Title>
                <Badge color='blue' variant='light'>
                    <Text size='xs' fw={600}>AVAILABLE</Text>
                </Badge>
            </Group>

            <Text size='sm' lineClamp={4} c='dimmed' pt={16} pb={16}>
               {props.summary}
            </Text>

            <Button color='blue' variant='light' fullWidth mt='md' radius='md' onClick={routeChange}>
                Vamos a jugar
            </Button>
        </Card>
    );
}

export default GameCard;