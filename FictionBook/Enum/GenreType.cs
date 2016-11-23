using System.Xml.Serialization;

namespace FictionBook.Library.Enum
{
    /// <summary>
    /// The genre type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0/genres")]
    public enum GenreType
    {
        /// <summary>
        ///     The architecture.
        /// </summary>
        /// <remarks>
        /// </remarks>
        architecture, 

        /// <summary>
        ///     The art.
        /// </summary>
        /// <remarks>
        /// </remarks>
        art, 

        /// <summary>
        ///     The art_instr.
        /// </summary>
        /// <remarks>
        /// </remarks>
        art_instr, 

        /// <summary>
        ///     The artists.
        /// </summary>
        /// <remarks>
        /// </remarks>
        artists, 

        /// <summary>
        ///     The fashion.
        /// </summary>
        /// <remarks>
        /// </remarks>
        fashion, 

        /// <summary>
        ///     The graph_design.
        /// </summary>
        /// <remarks>
        /// </remarks>
        graph_design, 

        /// <summary>
        ///     The performance.
        /// </summary>
        /// <remarks>
        /// </remarks>
        performance, 

        /// <summary>
        ///     The photography.
        /// </summary>
        /// <remarks>
        /// </remarks>
        photography, 

        /// <summary>
        ///     The people.
        /// </summary>
        /// <remarks>
        /// </remarks>
        people, 

        /// <summary>
        ///     The biography.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biography, 

        /// <summary>
        ///     The biogr_arts.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biogr_arts, 

        /// <summary>
        ///     The biogr_ethnic.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biogr_ethnic, 

        /// <summary>
        ///     The biogr_family.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biogr_family, 

        /// <summary>
        ///     The biogr_historical.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biogr_historical, 

        /// <summary>
        ///     The biogr_leaders.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biogr_leaders, 

        /// <summary>
        ///     The biogr_professionals.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biogr_professionals, 

        /// <summary>
        ///     The biogr_sports.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biogr_sports, 

        /// <summary>
        ///     The biogr_travel.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biogr_travel, 

        /// <summary>
        ///     The business.
        /// </summary>
        /// <remarks>
        /// </remarks>
        business, 

        /// <summary>
        ///     The biz_accounting.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_accounting, 

        /// <summary>
        ///     The biz_beogr.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_beogr, 

        /// <summary>
        ///     The biz_life.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_life, 

        /// <summary>
        ///     The biz_careers.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_careers, 

        /// <summary>
        ///     The biz_economics.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_economics, 

        /// <summary>
        ///     The biz_finance.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_finance, 

        /// <summary>
        ///     The biz_international.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_international, 

        /// <summary>
        ///     The biz_professions.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_professions, 

        /// <summary>
        ///     The biz_investing.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_investing, 

        /// <summary>
        ///     The biz_management.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_management, 

        /// <summary>
        ///     The biz_sales.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_sales, 

        /// <summary>
        ///     The biz_personal_fin.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_personal_fin, 

        /// <summary>
        ///     The biz_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_ref, 

        /// <summary>
        ///     The biz_small_biz.
        /// </summary>
        /// <remarks>
        /// </remarks>
        biz_small_biz, 

        /// <summary>
        ///     The child_3.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_3, 

        /// <summary>
        ///     The child_4.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_4, 

        /// <summary>
        ///     The child_9.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_9, 

        /// <summary>
        ///     The child_animals.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_animals, 

        /// <summary>
        ///     The child_art.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_art, 

        /// <summary>
        ///     The child_computers.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_computers, 

        /// <summary>
        ///     The child_edu.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_edu, 

        /// <summary>
        ///     The child_history.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_history, 

        /// <summary>
        ///     The child_obsessions.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_obsessions, 

        /// <summary>
        ///     The child_people.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_people, 

        /// <summary>
        ///     The child_characters.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_characters, 

        /// <summary>
        ///     The child_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_ref, 

        /// <summary>
        ///     The child_religion.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_religion, 

        /// <summary>
        ///     The child_nature.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_nature, 

        /// <summary>
        ///     The child_series.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_series, 

        /// <summary>
        ///     The child_sports.
        /// </summary>
        /// <remarks>
        /// </remarks>
        child_sports, 

        /// <summary>
        ///     The chris_bibles.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_bibles, 

        /// <summary>
        ///     The chris_pravoslavie.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_pravoslavie, 

        /// <summary>
        ///     The chris_catholicism.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_catholicism, 

        /// <summary>
        ///     The chris_living.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_living, 

        /// <summary>
        ///     The chris_history.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_history, 

        /// <summary>
        ///     The chris_clergy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_clergy, 

        /// <summary>
        ///     The chris_edu.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_edu, 

        /// <summary>
        ///     The chris_evangelism.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_evangelism, 

        /// <summary>
        ///     The chris_fiction.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_fiction, 

        /// <summary>
        ///     The chris_holidays.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_holidays, 

        /// <summary>
        ///     The chris_jesus.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_jesus, 

        /// <summary>
        ///     The chris_mormonism.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_mormonism, 

        /// <summary>
        ///     The chris_orthodoxy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_orthodoxy, 

        /// <summary>
        ///     The chris_protestantism.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_protestantism, 

        /// <summary>
        ///     The chris_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_ref, 

        /// <summary>
        ///     The chris_theology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_theology, 

        /// <summary>
        ///     The chris_devotion.
        /// </summary>
        /// <remarks>
        /// </remarks>
        chris_devotion, 

        /// <summary>
        ///     The computers.
        /// </summary>
        /// <remarks>
        /// </remarks>
        computers, 

        /// <summary>
        ///     The comp_office.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_office, 

        /// <summary>
        ///     The comp_cert.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_cert, 

        /// <summary>
        ///     The comp_games.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_games, 

        /// <summary>
        ///     The comp_sci.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_sci, 

        /// <summary>
        ///     The comp_db.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_db, 

        /// <summary>
        ///     The comp_biz.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_biz, 

        /// <summary>
        ///     The comp_graph.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_graph, 

        /// <summary>
        ///     The comp_hardware.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_hardware, 

        /// <summary>
        ///     The comp_microsoft.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_microsoft, 

        /// <summary>
        ///     The comp_networking.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_networking, 

        /// <summary>
        ///     The comp_os.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_os, 

        /// <summary>
        ///     The comp_programming.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_programming, 

        /// <summary>
        ///     The comp_software.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_software, 

        /// <summary>
        ///     The comp_www.
        /// </summary>
        /// <remarks>
        /// </remarks>
        comp_www, 

        /// <summary>
        ///     The cooking.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cooking, 

        /// <summary>
        ///     The cook_baking.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_baking, 

        /// <summary>
        ///     The cook_can.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_can, 

        /// <summary>
        ///     The cook_art.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_art, 

        /// <summary>
        ///     The cook_drink.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_drink, 

        /// <summary>
        ///     The cook_gastronomy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_gastronomy, 

        /// <summary>
        ///     The cook_meals.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_meals, 

        /// <summary>
        ///     The cook_natural.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_natural, 

        /// <summary>
        ///     The cook_outdoor.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_outdoor, 

        /// <summary>
        ///     The cook_pro.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_pro, 

        /// <summary>
        ///     The cook_quick.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_quick, 

        /// <summary>
        ///     The cook_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_ref, 

        /// <summary>
        ///     The cook_regional.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_regional, 

        /// <summary>
        ///     The cook_appliances.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_appliances, 

        /// <summary>
        ///     The cook_diet.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_diet, 

        /// <summary>
        ///     The cook_spec.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_spec, 

        /// <summary>
        ///     The cook_veget.
        /// </summary>
        /// <remarks>
        /// </remarks>
        cook_veget, 

        /// <summary>
        ///     The entertainment.
        /// </summary>
        /// <remarks>
        /// </remarks>
        entertainment, 

        /// <summary>
        ///     The entert_comics.
        /// </summary>
        /// <remarks>
        /// </remarks>
        entert_comics, 

        /// <summary>
        ///     The entert_games.
        /// </summary>
        /// <remarks>
        /// </remarks>
        entert_games, 

        /// <summary>
        ///     The entert_humor.
        /// </summary>
        /// <remarks>
        /// </remarks>
        entert_humor, 

        /// <summary>
        ///     The entert_movies.
        /// </summary>
        /// <remarks>
        /// </remarks>
        entert_movies, 

        /// <summary>
        ///     The entert_music.
        /// </summary>
        /// <remarks>
        /// </remarks>
        entert_music, 

        /// <summary>
        ///     The performance 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("performance")]
        performance1, 

        /// <summary>
        ///     The nonfiction_pop_culture.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_pop_culture, 

        /// <summary>
        ///     The entert_radio.
        /// </summary>
        /// <remarks>
        /// </remarks>
        entert_radio, 

        /// <summary>
        ///     The entert_tv.
        /// </summary>
        /// <remarks>
        /// </remarks>
        entert_tv, 

        /// <summary>
        ///     The gay_biogr.
        /// </summary>
        /// <remarks>
        /// </remarks>
        gay_biogr, 

        /// <summary>
        ///     The history_gay.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_gay, 

        /// <summary>
        ///     The literature_gay.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_gay, 

        /// <summary>
        ///     The gay_mystery.
        /// </summary>
        /// <remarks>
        /// </remarks>
        gay_mystery, 

        /// <summary>
        ///     The gay_nonfiction.
        /// </summary>
        /// <remarks>
        /// </remarks>
        gay_nonfiction, 

        /// <summary>
        ///     The gay_parenting.
        /// </summary>
        /// <remarks>
        /// </remarks>
        gay_parenting, 

        /// <summary>
        ///     The gay_travel.
        /// </summary>
        /// <remarks>
        /// </remarks>
        gay_travel, 

        /// <summary>
        ///     The health.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health, 

        /// <summary>
        ///     The health_aging.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_aging, 

        /// <summary>
        ///     The health_alt_medicine.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_alt_medicine, 

        /// <summary>
        ///     The health_beauty.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_beauty, 

        /// <summary>
        ///     The health_cancer.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_cancer, 

        /// <summary>
        ///     The health_death.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_death, 

        /// <summary>
        ///     The health_diets.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_diets, 

        /// <summary>
        ///     The health_dideases.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_dideases, 

        /// <summary>
        ///     The health_fitness.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_fitness, 

        /// <summary>
        ///     The health_men.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_men, 

        /// <summary>
        ///     The health_mental.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_mental, 

        /// <summary>
        ///     The health_nutrition.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_nutrition, 

        /// <summary>
        ///     The health_personal.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_personal, 

        /// <summary>
        ///     The health_psy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_psy, 

        /// <summary>
        ///     The health_recovery.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_recovery, 

        /// <summary>
        ///     The health_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_ref, 

        /// <summary>
        ///     The health_rel.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_rel, 

        /// <summary>
        ///     The health_first_aid.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_first_aid, 

        /// <summary>
        ///     The health_self_help.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_self_help, 

        /// <summary>
        ///     The health_sex.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_sex, 

        /// <summary>
        ///     The health_women.
        /// </summary>
        /// <remarks>
        /// </remarks>
        health_women, 

        /// <summary>
        ///     The history_africa.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_africa, 

        /// <summary>
        ///     The history_america.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_america, 

        /// <summary>
        ///     The history_ancient.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_ancient, 

        /// <summary>
        ///     The history_asia.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_asia, 

        /// <summary>
        ///     The history_australia.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_australia, 

        /// <summary>
        ///     The history_europe.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_europe, 

        /// <summary>
        ///     The history_study.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_study, 

        /// <summary>
        ///     The history_jewish.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_jewish, 

        /// <summary>
        ///     The history_middle_east.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_middle_east, 

        /// <summary>
        ///     The histor_military.
        /// </summary>
        /// <remarks>
        /// </remarks>
        histor_military, 

        /// <summary>
        ///     The history_military_science.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_military_science, 

        /// <summary>
        ///     The history_russia.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_russia, 

        /// <summary>
        ///     The history_usa.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_usa, 

        /// <summary>
        ///     The history_world.
        /// </summary>
        /// <remarks>
        /// </remarks>
        history_world, 

        /// <summary>
        ///     The history_gay 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("history_gay")]
        history_gay1, 

        /// <summary>
        ///     The home_pets.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_pets, 

        /// <summary>
        ///     The home_collect.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_collect, 

        /// <summary>
        ///     The home_crafts.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_crafts, 

        /// <summary>
        ///     The home_entertain.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_entertain, 

        /// <summary>
        ///     The home_expert.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_expert, 

        /// <summary>
        ///     The home_garden.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_garden, 

        /// <summary>
        ///     The home_design.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_design, 

        /// <summary>
        ///     The home_howto.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_howto, 

        /// <summary>
        ///     The home_interior_design.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_interior_design, 

        /// <summary>
        ///     The home_cottage.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_cottage, 

        /// <summary>
        ///     The home_weddings.
        /// </summary>
        /// <remarks>
        /// </remarks>
        home_weddings, 

        /// <summary>
        ///     The horror.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror, 

        /// <summary>
        ///     The horror_antology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror_antology, 

        /// <summary>
        ///     The horror_british.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror_british, 

        /// <summary>
        ///     The horror_fantasy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror_fantasy, 

        /// <summary>
        ///     The horror_erotic.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror_erotic, 

        /// <summary>
        ///     The horror_ghosts.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror_ghosts, 

        /// <summary>
        ///     The horror_graphic.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror_graphic, 

        /// <summary>
        ///     The horror_occult.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror_occult, 

        /// <summary>
        ///     The horror_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror_ref, 

        /// <summary>
        ///     The horror_usa.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror_usa, 

        /// <summary>
        ///     The horror_vampires.
        /// </summary>
        /// <remarks>
        /// </remarks>
        horror_vampires, 

        /// <summary>
        ///     The literature.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature, 

        /// <summary>
        ///     The literature_books.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_books, 

        /// <summary>
        ///     The literature_british.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_british, 

        /// <summary>
        ///     The literature_classics.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_classics, 

        /// <summary>
        ///     The literature_drama.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_drama, 

        /// <summary>
        ///     The literature_essay.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_essay, 

        /// <summary>
        ///     The literature_adv.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_adv, 

        /// <summary>
        ///     The literature_antology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_antology, 

        /// <summary>
        ///     The literature_erotica.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_erotica, 

        /// <summary>
        ///     The literature_fairy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_fairy, 

        /// <summary>
        ///     The literature_saga.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_saga, 

        /// <summary>
        ///     The literature_gay 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("literature_gay")]
        literature_gay1, 

        /// <summary>
        ///     The literature_history.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_history, 

        /// <summary>
        ///     The literature_men_advent.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_men_advent, 

        /// <summary>
        ///     The literature_political.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_political, 

        /// <summary>
        ///     The literature_religion.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_religion, 

        /// <summary>
        ///     The literature_sea.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_sea, 

        /// <summary>
        ///     The literature_sports.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_sports, 

        /// <summary>
        ///     The literature_war.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_war, 

        /// <summary>
        ///     The literature_western.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_western, 

        /// <summary>
        ///     The literature_critic.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_critic, 

        /// <summary>
        ///     The literature_letters.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_letters, 

        /// <summary>
        ///     The literature_poetry.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_poetry, 

        /// <summary>
        ///     The literature_short.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_short, 

        /// <summary>
        ///     The literature_usa.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_usa, 

        /// <summary>
        ///     The literature_women.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_women, 

        /// <summary>
        ///     The literature_world.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_world, 

        /// <summary>
        ///     The literature_rus_classsic.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_rus_classsic, 

        /// <summary>
        ///     The literature_su_classics.
        /// </summary>
        /// <remarks>
        /// </remarks>
        literature_su_classics, 

        /// <summary>
        ///     The mystery.
        /// </summary>
        /// <remarks>
        /// </remarks>
        mystery, 

        /// <summary>
        ///     The thriller_mystery.
        /// </summary>
        /// <remarks>
        /// </remarks>
        thriller_mystery, 

        /// <summary>
        ///     The thriller_police.
        /// </summary>
        /// <remarks>
        /// </remarks>
        thriller_police, 

        /// <summary>
        ///     The thriller.
        /// </summary>
        /// <remarks>
        /// </remarks>
        thriller, 

        /// <summary>
        ///     The nonfiction_avto.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_avto, 

        /// <summary>
        ///     The nonfiction_crime.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_crime, 

        /// <summary>
        ///     The nonfiction_events.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_events, 

        /// <summary>
        ///     The biz_economics 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("biz_economics")]
        biz_economics1, 

        /// <summary>
        ///     The nonfiction_edu.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_edu, 

        /// <summary>
        ///     The nonfiction_gov.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_gov, 

        /// <summary>
        ///     The nonfiction_holidays.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_holidays, 

        /// <summary>
        ///     The nonfiction_law.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_law, 

        /// <summary>
        ///     The nonfiction_philosophy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_philosophy, 

        /// <summary>
        ///     The nonfiction_politics.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_politics, 

        /// <summary>
        ///     The nonfiction_social_sci.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_social_sci, 

        /// <summary>
        ///     The nonfiction_antropology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_antropology, 

        /// <summary>
        ///     The science_archaeology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_archaeology, 

        /// <summary>
        ///     The nonfiction_traditions.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_traditions, 

        /// <summary>
        ///     The nonfiction_demography.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_demography, 

        /// <summary>
        ///     The nonfiction_racism.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_racism, 

        /// <summary>
        ///     The nonfiction_emigration.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_emigration, 

        /// <summary>
        ///     The nonfiction_ethnology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_ethnology, 

        /// <summary>
        ///     The nonfiction_folklor.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_folklor, 

        /// <summary>
        ///     The nonfiction_gender.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_gender, 

        /// <summary>
        ///     The nonfiction_gerontology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_gerontology, 

        /// <summary>
        ///     The nonfiction_hum_geogr.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_hum_geogr, 

        /// <summary>
        ///     The nonfiction_methodology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_methodology, 

        /// <summary>
        ///     The nonfiction_philantropy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_philantropy, 

        /// <summary>
        ///     The nonfiction_pop_culture 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("nonfiction_pop_culture")]
        nonfiction_pop_culture1, 

        /// <summary>
        ///     The nonfiction_pornography.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_pornography, 

        /// <summary>
        ///     The nonfiction_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_ref, 

        /// <summary>
        ///     The nonfiction_research.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_research, 

        /// <summary>
        ///     The nonfiction_social_work.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_social_work, 

        /// <summary>
        ///     The nonfiction_sociology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_sociology, 

        /// <summary>
        ///     The nonfiction_spec_group.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_spec_group, 

        /// <summary>
        ///     The nonfiction_stat.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_stat, 

        /// <summary>
        ///     The health_psy 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("health_psy")]
        health_psy1, 

        /// <summary>
        ///     The nonfiction_transportation.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_transportation, 

        /// <summary>
        ///     The nonfiction_true_accounts.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_true_accounts, 

        /// <summary>
        ///     The nonfiction_urban.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_urban, 

        /// <summary>
        ///     The nonfiction_women.
        /// </summary>
        /// <remarks>
        /// </remarks>
        nonfiction_women, 

        /// <summary>
        ///     The outdoors_birdwatching.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_birdwatching, 

        /// <summary>
        ///     The outdoors_conservation.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_conservation, 

        /// <summary>
        ///     The outdoors_ecology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_ecology, 

        /// <summary>
        ///     The outdoors_ecosystems.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_ecosystems, 

        /// <summary>
        ///     The outdoors_env.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_env, 

        /// <summary>
        ///     The outdoors_fauna.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_fauna, 

        /// <summary>
        ///     The outdoors_field_guides.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_field_guides, 

        /// <summary>
        ///     The outdoors_flora.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_flora, 

        /// <summary>
        ///     The outdoors_hiking.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_hiking, 

        /// <summary>
        ///     The outdoors_hunt_fish.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_hunt_fish, 

        /// <summary>
        ///     The outdoors_resources.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_resources, 

        /// <summary>
        ///     The outdoors_nature_writing.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_nature_writing, 

        /// <summary>
        ///     The outdoors_outdoor_recreation.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_outdoor_recreation, 

        /// <summary>
        ///     The outdoors_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_ref, 

        /// <summary>
        ///     The outdoors_survive.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_survive, 

        /// <summary>
        ///     The outdoors_travel.
        /// </summary>
        /// <remarks>
        /// </remarks>
        outdoors_travel, 

        /// <summary>
        ///     The family.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family, 

        /// <summary>
        ///     The family_adoption.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_adoption, 

        /// <summary>
        ///     The family_aging_parents.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_aging_parents, 

        /// <summary>
        ///     The family_edu.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_edu, 

        /// <summary>
        ///     The family_activities.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_activities, 

        /// <summary>
        ///     The family_health.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_health, 

        /// <summary>
        ///     The family_relations.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_relations, 

        /// <summary>
        ///     The family_fertility.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_fertility, 

        /// <summary>
        ///     The family_humor.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_humor, 

        /// <summary>
        ///     The family_lit_guide.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_lit_guide, 

        /// <summary>
        ///     The family_parenting.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_parenting, 

        /// <summary>
        ///     The family_pregnancy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_pregnancy, 

        /// <summary>
        ///     The family_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_ref, 

        /// <summary>
        ///     The family_special_needs.
        /// </summary>
        /// <remarks>
        /// </remarks>
        family_special_needs, 

        /// <summary>
        ///     The professional_finance.
        /// </summary>
        /// <remarks>
        /// </remarks>
        professional_finance, 

        /// <summary>
        ///     The architecture 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("architecture")]
        architecture1, 

        /// <summary>
        ///     The professional_management.
        /// </summary>
        /// <remarks>
        /// </remarks>
        professional_management, 

        /// <summary>
        ///     The professional_edu.
        /// </summary>
        /// <remarks>
        /// </remarks>
        professional_edu, 

        /// <summary>
        ///     The professional_enginering.
        /// </summary>
        /// <remarks>
        /// </remarks>
        professional_enginering, 

        /// <summary>
        ///     The professional_law.
        /// </summary>
        /// <remarks>
        /// </remarks>
        professional_law, 

        /// <summary>
        ///     The professional_medical.
        /// </summary>
        /// <remarks>
        /// </remarks>
        professional_medical, 

        /// <summary>
        ///     The professional_sci.
        /// </summary>
        /// <remarks>
        /// </remarks>
        professional_sci, 

        /// <summary>
        ///     The references.
        /// </summary>
        /// <remarks>
        /// </remarks>
        references, 

        /// <summary>
        ///     The ref_almanacs.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_almanacs, 

        /// <summary>
        ///     The biz_ref 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("biz_ref")]
        biz_ref1, 

        /// <summary>
        ///     The ref_careers.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_careers, 

        /// <summary>
        ///     The ref_catalogs.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_catalogs, 

        /// <summary>
        ///     The ref_cons_guides.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_cons_guides, 

        /// <summary>
        ///     The ref_dict.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_dict, 

        /// <summary>
        ///     The ref_edu.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_edu, 

        /// <summary>
        ///     The ref_encyclopedia.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_encyclopedia, 

        /// <summary>
        ///     The ref_etiquette.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_etiquette, 

        /// <summary>
        ///     The ref_langs.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_langs, 

        /// <summary>
        ///     The ref_fun.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_fun, 

        /// <summary>
        ///     The ref_genealogy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_genealogy, 

        /// <summary>
        ///     The nonfiction_law 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("nonfiction_law")]
        nonfiction_law1, 

        /// <summary>
        ///     The ref_books.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_books, 

        /// <summary>
        ///     The ref_quotations.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_quotations, 

        /// <summary>
        ///     The ref_study_guides.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_study_guides, 

        /// <summary>
        ///     The ref_words.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_words, 

        /// <summary>
        ///     The ref_writing.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ref_writing, 

        /// <summary>
        ///     The religion.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion, 

        /// <summary>
        ///     The religion_bibles.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_bibles, 

        /// <summary>
        ///     The religion_buddhism.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_buddhism, 

        /// <summary>
        ///     The religion_earth.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_earth, 

        /// <summary>
        ///     The religion_fiction.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_fiction, 

        /// <summary>
        ///     The religion_hinduism.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_hinduism, 

        /// <summary>
        ///     The religion_islam.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_islam, 

        /// <summary>
        ///     The religion_judaism.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_judaism, 

        /// <summary>
        ///     The religion_new_age.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_new_age, 

        /// <summary>
        ///     The religion_occult.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_occult, 

        /// <summary>
        ///     The religion_religious_studies.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_religious_studies, 

        /// <summary>
        ///     The religion_spirituality.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_spirituality, 

        /// <summary>
        ///     The religion_east.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_east, 

        /// <summary>
        ///     The religion_other.
        /// </summary>
        /// <remarks>
        /// </remarks>
        religion_other, 

        /// <summary>
        ///     The romance.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance, 

        /// <summary>
        ///     The romance_anthologies.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_anthologies, 

        /// <summary>
        ///     The romance_contemporary.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_contemporary, 

        /// <summary>
        ///     The romance_fantasy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_fantasy, 

        /// <summary>
        ///     The romance_sf.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_sf, 

        /// <summary>
        ///     The romance_historical.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_historical, 

        /// <summary>
        ///     The romance_multicultural.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_multicultural, 

        /// <summary>
        ///     The romance_regency.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_regency, 

        /// <summary>
        ///     The romance_religion.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_religion, 

        /// <summary>
        ///     The romance_romantic_suspense.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_romantic_suspense, 

        /// <summary>
        ///     The romance_series.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_series, 

        /// <summary>
        ///     The romance_time_travel.
        /// </summary>
        /// <remarks>
        /// </remarks>
        romance_time_travel, 

        /// <summary>
        ///     The ref_writing 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("ref_writing")]
        ref_writing1, 

        /// <summary>
        ///     The science.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science, 

        /// <summary>
        ///     The science_agri.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_agri, 

        /// <summary>
        ///     The science_archaeology 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("science_archaeology")]
        science_archaeology1, 

        /// <summary>
        ///     The science_astronomy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_astronomy, 

        /// <summary>
        ///     The science_behavioralsciences.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("science_behavioral sciences")]
        science_behavioralsciences, 

        /// <summary>
        ///     The science_psy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_psy, 

        /// <summary>
        ///     The science_biolog.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_biolog, 

        /// <summary>
        ///     The science_chemistry.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_chemistry, 

        /// <summary>
        ///     The science_earth.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_earth, 

        /// <summary>
        ///     The science_edu.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_edu, 

        /// <summary>
        ///     The science_evolution.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_evolution, 

        /// <summary>
        ///     The science_measurement.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_measurement, 

        /// <summary>
        ///     The science_history_philosophy.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_history_philosophy, 

        /// <summary>
        ///     The science_math.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_math, 

        /// <summary>
        ///     The science_medicine.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_medicine, 

        /// <summary>
        ///     The science_eco.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_eco, 

        /// <summary>
        ///     The science_physics.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_physics, 

        /// <summary>
        ///     The science_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_ref, 

        /// <summary>
        ///     The science_technology.
        /// </summary>
        /// <remarks>
        /// </remarks>
        science_technology, 

        /// <summary>
        ///     The romance_sf 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("romance_sf")]
        romance_sf1, 

        /// <summary>
        ///     The romance_fantasy 1.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [XmlEnum("romance_fantasy")]
        romance_fantasy1, 

        /// <summary>
        ///     The gaming.
        /// </summary>
        /// <remarks>
        /// </remarks>
        gaming, 

        /// <summary>
        ///     The sf_writing.
        /// </summary>
        /// <remarks>
        /// </remarks>
        sf_writing, 

        /// <summary>
        ///     The fantasy_alt_hist.
        /// </summary>
        /// <remarks>
        /// </remarks>
        fantasy_alt_hist, 

        /// <summary>
        ///     The sf_cyber_punk.
        /// </summary>
        /// <remarks>
        /// </remarks>
        sf_cyber_punk, 

        /// <summary>
        ///     The sport.
        /// </summary>
        /// <remarks>
        /// </remarks>
        sport, 

        /// <summary>
        ///     The teens_beogr.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_beogr, 

        /// <summary>
        ///     The teens_health.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_health, 

        /// <summary>
        ///     The teens_history.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_history, 

        /// <summary>
        ///     The teens_horror.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_horror, 

        /// <summary>
        ///     The teens_literature.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_literature, 

        /// <summary>
        ///     The teens_mysteries.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_mysteries, 

        /// <summary>
        ///     The teens_ref.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_ref, 

        /// <summary>
        ///     The teens_religion.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_religion, 

        /// <summary>
        ///     The teens_school_sports.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_school_sports, 

        /// <summary>
        ///     The teens_sf.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_sf, 

        /// <summary>
        ///     The teens_tech.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_tech, 

        /// <summary>
        ///     The teens_series.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_series, 

        /// <summary>
        ///     The teens_social.
        /// </summary>
        /// <remarks>
        /// </remarks>
        teens_social, 

        /// <summary>
        ///     The travel.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel, 

        /// <summary>
        ///     The travel_africa.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_africa, 

        /// <summary>
        ///     The travel_asia.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_asia, 

        /// <summary>
        ///     The travel_australia.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_australia, 

        /// <summary>
        ///     The travel_canada.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_canada, 

        /// <summary>
        ///     The travel_caribbean.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_caribbean, 

        /// <summary>
        ///     The travel_europe.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_europe, 

        /// <summary>
        ///     The travel_guidebook_series.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_guidebook_series, 

        /// <summary>
        ///     The travel_lat_am.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_lat_am, 

        /// <summary>
        ///     The travel_middle_east.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_middle_east, 

        /// <summary>
        ///     The travel_polar.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_polar, 

        /// <summary>
        ///     The travel_spec.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_spec, 

        /// <summary>
        ///     The travel_usa.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_usa, 

        /// <summary>
        ///     The travel_rus.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_rus, 

        /// <summary>
        ///     The travel_ex_ussr.
        /// </summary>
        /// <remarks>
        /// </remarks>
        travel_ex_ussr, 

        /// <summary>
        ///     The women_divorce.
        /// </summary>
        /// <remarks>
        /// </remarks>
        women_divorce, 

        /// <summary>
        ///     The women_domestic.
        /// </summary>
        /// <remarks>
        /// </remarks>
        women_domestic, 

        /// <summary>
        ///     The women_child.
        /// </summary>
        /// <remarks>
        /// </remarks>
        women_child, 

        /// <summary>
        ///     The women_single.
        /// </summary>
        /// <remarks>
        /// </remarks>
        women_single
    }
}