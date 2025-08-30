import { CssBaseline, ThemeProvider, Container, Typography, Button } from '@mui/material';
import { makeTheme } from './theme';
import { useEffect, useMemo, useState } from 'react';
import { useGetHealthQuery } from './svc/api';
import { useTranslation } from 'react-i18next';
import { useGetEmployeesQuery } from './svc/api';
import { hub } from './realtime';

export default function App() {
    const { data } = useGetHealthQuery();
    const { i18n, t } = useTranslation();
    const [dir, setDir] = useState<'rtl' | 'ltr'>(i18n.language.startsWith('he') ? 'rtl' : 'ltr');

    useEffect(() => {
        const d = i18n.language.startsWith('he') ? 'rtl' : 'ltr';
        setDir(d);
        document.documentElement.setAttribute('dir', d);
    }, [i18n.language]);

    useEffect(() => {
        hub.start()
            .catch(console.error);
        return () => { hub.stop(); };
    }, []);

    const theme = useMemo(() => makeTheme(dir), [dir]);

    const { data: employees } = useGetEmployeesQuery();

    return (
        <ThemeProvider theme={theme}>
            <CssBaseline />
            <Container sx={{ py: '2rem' }}>
                <Typography variant="h4" gutterBottom>{t('hello')} ShiftWise</Typography>
                <Typography>API health: {data?.status ?? '...'}</Typography>
                <Button onClick={() => i18n.changeLanguage(i18n.language.startsWith('he') ? 'en' : 'he')}>
                    Toggle Language
                </Button>

                {employees?.map((e) => (
                    <div key={e.id}>{e.fullName}</div>
                ))}
            </Container>
        </ThemeProvider>
    );
}
