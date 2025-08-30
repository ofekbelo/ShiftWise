import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';
import LanguageDetector from 'i18next-browser-languagedetector';

const resources = {
    he: { translation: { hello: 'שלום', employees: 'עובדים' } },
    en: { translation: { hello: 'Hello', employees: 'Employees' } },
    es: { translation: { hello: 'Hola', employees: 'Empleados' } },
};

i18n
    .use(LanguageDetector)
    .use(initReactI18next)
    .init({
        resources,
        fallbackLng: 'he',
        interpolation: { escapeValue: false },
    });

export default i18n;
