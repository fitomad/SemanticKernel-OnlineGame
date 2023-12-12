import { Container, SimpleGrid } from '@mantine/core'

import AppLogo from 'src/components/header/AppLogo.jsx';
import AppMenu from 'src/components/header/AppMenu.jsx';
import AppSocial from 'src/components/header/AppSocial.jsx';

function AppHeader() {
    return(
        <Container fluid>
            <SimpleGrid cols={3} pt={24}>
                <AppLogo />
                <AppMenu />
                <AppSocial />
            </SimpleGrid>
        </Container>
    );
}

export default AppHeader;